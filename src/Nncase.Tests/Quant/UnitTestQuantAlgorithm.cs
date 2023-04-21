﻿// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Nncase;
using Nncase.IR;
using Nncase.Passes;
using Nncase.Passes.Rules.Neutral;
using Nncase.Quantization;
using Nncase.Tests.TestFixture;
using Nncase.Utilities;
using Xunit;
using static Nncase.IR.F.NN;
using static Nncase.IR.F.Random;
using static Nncase.IR.F.Tensors;
using static Nncase.PatternMatch.F.Math;
using static Nncase.PatternMatch.Utility;
using static Nncase.Quantization.Utility;
using static Nncase.Tests.DataGenerator;
using Random = Nncase.IR.F.Random;

namespace Nncase.Tests.QuantTest;

[AutoSetupTestMethod(InitSession = true)]
public class UnitTestKLQuant : TestClassBase
{
    [Fact]
    public void TestQuantFunction()
    {
        var range = new ValueRange<float>(-1.234f, 2.345f);
        var qp = QuantUtility.GetQuantParam(range, 8, QuantMode.UnsignedMode);
        Assert.Equal(0.014035294f, qp.Scale);
        Assert.Equal(88, qp.ZeroPoint);
    }

    [Fact]
    public void TestGetWeightsRangesByChannel()
    {
        Span<float> weightsValue = stackalloc float[16 * 3 * 3 * 3];
        for (int i = 0; i < 16 * 3 * 3 * 3; i++)
        {
            weightsValue[i] = 1.0f;
        }

        List<float> byChannelRanges = QuantUtility.GetWeightsRangesByChannel(weightsValue, 16);
        for (int i = 0; i < 16 * 2; i++)
        {
            if (i % 2 == 0)
            {
                Assert.Equal(0.0f, byChannelRanges[i]);
            }
            else
            {
                Assert.Equal(1.0f, byChannelRanges[i]);
            }
        }
    }

    [Fact]
    public async Task TestKLQuant()
    {
        CompileOptions.QuantizeOptions.ModelQuantMode = ModelQuantMode.UsePTQ;
        CompileOptions.QuantizeOptions.QuantType = DataTypes.UInt8;
        CompileOptions.QuantizeOptions.WQuantType = DataTypes.UInt8;

        var input = new Var("input", new TensorType(DataTypes.Float32, new[] { 1, 3, 224, 224 }));

        var weightsValue = new List<float>();
        for (int i = 0; i < 16 * 3 * 3 * 3; i++)
        {
            weightsValue.Add(((i * 1.0f / (16 * 3 * 3 * 3)) - 0.5f) * 2);
        }

        var biasValue = new List<float>();
        for (int i = 0; i < 16; i++)
        {
            biasValue.Add(((i * 1.0f / 16) - 0.5f) * 2);
        }

        var weights = Tensor.From<float>(weightsValue.ToArray(), new[] { 16, 3, 3, 3 });
        var bias = Tensor.From<float>(biasValue.ToArray(), new[] { 16 });
        var stride = Tensor.From<int>(new[] { 1, 1 }, new[] { 2 });
        var dilation = Tensor.From<int>(new[] { 1, 1 }, new[] { 2 });
        var padding = new[] { new[] { 0, 1 }, new[] { 0, 0 } };

        var conv = IR.F.NN.Conv2D(input, weights, bias, stride, Pad(padding), dilation, PadMode.Constant, 1);

        var output = conv;
        var module = new IRModule(new Function("main", output, new Var[] { input }));

        CompileOptions.QuantizeOptions.CalibrationDataset = new SolidCalibrationDatasetProvider(new Var[] { input });
        CompileOptions.QuantizeOptions.CalibrationMethod = CalibMethod.Kld;

        var pmgr = CompileSession.CreatePassManager("Passes");

        // 0. TargetIndependentPass
        pmgr.AddWithName<DataflowPass>("TargetInDependent").Configure(p =>
        {
            p.Add<AddRangeOfAndMarker>();
        });

        // 1. AssignRanges
        pmgr.AddWithName<EGraphPassWithQuantize>("AssignRanges");
        await pmgr.RunAsync(module);

        var dumpVisitor = new DumpVisitor();
        dumpVisitor.Visit(module.Functions[0]);

        Assert.Equal(-1.0001221f, ((TensorConst)dumpVisitor.ExprMemo.Keys.ToList()[2]).Value.ToArray<float>()[0]);
        Assert.Equal(1.0001087f, ((TensorConst)dumpVisitor.ExprMemo.Keys.ToList()[2]).Value.ToArray<float>()[1]);
        Assert.Equal(-1.0001218f, ((TensorConst)dumpVisitor.ExprMemo.Keys.ToList()[5]).Value.ToArray<float>()[0]);
        Assert.Equal(0.9954922f, ((TensorConst)dumpVisitor.ExprMemo.Keys.ToList()[5]).Value.ToArray<float>()[1]);
        Assert.Equal(-8.882528f, ((TensorConst)dumpVisitor.ExprMemo.Keys.ToList()[13]).Value.ToArray<float>()[0]);
        Assert.Equal(9.717726f, ((TensorConst)dumpVisitor.ExprMemo.Keys.ToList()[13]).Value.ToArray<float>()[1]);
    }

    private Expr Pad(int[][] p) => Const.FromTensor(Tensor.From<int>(p.SelectMany(i => i).ToArray(), new[] { 2, 2 }));

    public sealed class DumpVisitor : ExprVisitor<int, IRType>
    {
        public int FoundOpCount<T>()
          where T : Op
        {
            return ExprMemo.Keys.OfType<T>().Count();
        }

        protected override int DefaultVisitLeaf(Expr expr) => 0;
    }

    internal sealed class RandCalibrationDatasetProvider : ICalibrationDatasetProvider
    {
        private const int CountValue = 5;

        public RandCalibrationDatasetProvider(IEnumerable<Var> vars)
        {
            Samples = Enumerable.Range(0, CountValue).Select(i =>
            {
                var values = new Dictionary<Var, IValue>();
                foreach (var var in vars)
                {
                    CompilerServices.InferenceType(var);
                    var shape = var.CheckedShape.Select(d => d.IsUnknown ? 1 : d.FixedValue).ToArray();
                    var value = Value.FromTensor(IR.F.Random.Normal(var.CheckedDataType, 0, 1, 0, shape).Evaluate()
                        .AsTensor());
                    values.Add(var, value);
                }

                return values;
            }).ToArray().ToAsyncEnumerable();
        }

        public int? Count => CountValue;

        public IAsyncEnumerable<IReadOnlyDictionary<Var, IValue>> Samples { get; }
    }

    internal sealed class SolidCalibrationDatasetProvider : ICalibrationDatasetProvider
    {
        private const int CountValue = 5;

        public SolidCalibrationDatasetProvider(IEnumerable<Var> vars)
        {
            Samples = Enumerable.Range(0, CountValue).Select(i =>
            {
                var values = new Dictionary<Var, IValue>();
                foreach (var var in vars)
                {
                    CompilerServices.InferenceType(var);
                    var shape = var.CheckedShape.Select(d => d.IsUnknown ? 1 : d.FixedValue).ToArray();

                    var shapeSize = 1;
                    for (int j = 0; j < shape.Length; j++)
                    {
                        shapeSize *= shape[j];
                    }

                    var tmpValue = new List<float>();
                    for (int j = 0; j < shapeSize; j++)
                    {
                        tmpValue.Add(((j * 1.0f / shapeSize) - 0.5f) * 2);
                    }

                    var value = Value.FromTensor(Tensor.From<float>(tmpValue.ToArray(), shape));
                    values.Add(var, value);
                }

                return values;
            }).ToAsyncEnumerable();
        }

        public int? Count => CountValue;

        public IAsyncEnumerable<IReadOnlyDictionary<Var, IValue>> Samples { get; }
    }
}