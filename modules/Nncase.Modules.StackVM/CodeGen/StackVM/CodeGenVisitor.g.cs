// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.
/* This file is generated by tools/stackvm_gen/IsaGen at 5/22/2023 1:37:38PM +08:00. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nncase.IR;
using Nncase.Runtime.StackVM;

namespace Nncase.CodeGen.StackVM;

internal partial class CodeGenVisitor
{
    private void EmitTensorCall(Op op)
    {
        switch (op)
        {
            case IR.NN.BatchNormalization top:
                Emitter.T.BatchNormalization();
                break;
            case IR.NN.BatchToSpace top:
                Emitter.T.BatchToSpace();
                break;
            case IR.NN.Celu top:
                Emitter.T.Celu();
                break;
            case IR.NN.Conv2D top:
                Emitter.T.Conv2D(top.PadMode);
                break;
            case IR.NN.Conv2DTranspose top:
                Emitter.T.Conv2DTranspose(top.PadMode);
                break;
            case IR.NN.Elu top:
                Emitter.T.Elu();
                break;
            case IR.NN.Erf top:
                Emitter.T.Erf();
                break;
            case IR.NN.Gelu top:
                Emitter.T.Gelu();
                break;
            case IR.NN.Hardmax top:
                Emitter.T.Hardmax();
                break;
            case IR.NN.HardSigmoid top:
                Emitter.T.HardSigmoid();
                break;
            case IR.NN.HardSwish top:
                Emitter.T.HardSwish();
                break;
            case IR.NN.InstanceNormalization top:
                Emitter.T.InstanceNormalization();
                break;
            case IR.NN.L2Normalization top:
                Emitter.T.L2Normalization();
                break;
            case IR.NN.LayerNorm top:
                Emitter.T.LayerNorm(top.Axis, top.Epsilon);
                break;
            case IR.NN.LeakyRelu top:
                Emitter.T.LeakyRelu();
                break;
            case IR.NN.LogSoftmax top:
                Emitter.T.LogSoftmax();
                break;
            case IR.NN.LpNormalization top:
                Emitter.T.LpNormalization();
                break;
            case IR.NN.LRN top:
                Emitter.T.LRN();
                break;
            case IR.NN.OneHot top:
                Emitter.T.OneHot(top.OneHotMode);
                break;
            case IR.NN.Pad top:
                Emitter.T.Pad(top.PadMode);
                break;
            case IR.NN.PRelu top:
                Emitter.T.PRelu();
                break;
            case IR.NN.ReduceWindow2D top:
                Emitter.T.ReduceWindow2D(top.ReduceOp);
                break;
            case IR.NN.Relu top:
                Emitter.T.Relu();
                break;
            case IR.NN.Relu6 top:
                Emitter.T.Relu6();
                break;
            case IR.NN.Selu top:
                Emitter.T.Selu();
                break;
            case IR.NN.Sigmoid top:
                Emitter.T.Sigmoid();
                break;
            case IR.NN.Softmax top:
                Emitter.T.Softmax();
                break;
            case IR.NN.Softplus top:
                Emitter.T.Softplus();
                break;
            case IR.NN.Softsign top:
                Emitter.T.Softsign();
                break;
            case IR.NN.SpaceToBatch top:
                Emitter.T.SpaceToBatch();
                break;
            case IR.NN.Swish top:
                Emitter.T.Swish();
                break;
            case IR.Math.Binary top:
                Emitter.T.Binary(top.BinaryOp);
                break;
            case IR.Math.Clamp top:
                Emitter.T.Clamp();
                break;
            case IR.Math.Compare top:
                Emitter.T.Compare(top.CompareOp);
                break;
            case IR.Math.Condition top:
                Emitter.T.Condition(top.CanFoldConstCall);
                break;
            case IR.Math.CumSum top:
                Emitter.T.CumSum();
                break;
            case IR.Math.Dequantize top:
                Emitter.T.Dequantize(top.TargetType);
                break;
            case IR.Math.FakeDequantize top:
                Emitter.T.FakeDequantize(top.TargetType);
                break;
            case IR.Math.FakeQuantize top:
                Emitter.T.FakeQuantize(top.TargetType);
                break;
            case IR.Math.MatMul top:
                Emitter.T.MatMul();
                break;
            case IR.Math.Quantize top:
                Emitter.T.Quantize(top.TargetType);
                break;
            case IR.Math.QuantParamOf top:
                Emitter.T.QuantParamOf(top.QuantMode);
                break;
            case IR.Math.RangeOf top:
                Emitter.T.RangeOf(top.IsRangeOfWeight);
                break;
            case IR.Math.Reduce top:
                Emitter.T.Reduce(top.ReduceOp);
                break;
            case IR.Math.ReduceArg top:
                Emitter.T.ReduceArg(top.ReduceArgOp, top.DestType);
                break;
            case IR.Math.Require top:
                Emitter.T.Require(top.Message);
                break;
            case IR.Math.Select top:
                Emitter.T.Select();
                break;
            case IR.Math.Unary top:
                Emitter.T.Unary(top.UnaryOp);
                break;
            case IR.Tensors.Bitcast top:
                Emitter.T.Bitcast(top.Type, top.NewType);
                break;
            case IR.Tensors.Broadcast top:
                Emitter.T.Broadcast();
                break;
            case IR.Tensors.Cast top:
                Emitter.T.Cast(top.NewType, top.CastMode);
                break;
            case IR.Tensors.Concat top:
                Emitter.T.Concat();
                break;
            case IR.Tensors.ConstantOfShape top:
                Emitter.T.ConstantOfShape();
                break;
            case IR.Tensors.Expand top:
                Emitter.T.Expand();
                break;
            case IR.Tensors.Flatten top:
                Emitter.T.Flatten();
                break;
            case IR.Tensors.Gather top:
                Emitter.T.Gather();
                break;
            case IR.Tensors.GatherElements top:
                Emitter.T.GatherElements();
                break;
            case IR.Tensors.GatherND top:
                Emitter.T.GatherND();
                break;
            case IR.Tensors.GetItem top:
                Emitter.T.GetItem();
                break;
            case IR.Tensors.LSTM top:
                Emitter.T.LSTM(top.Direction, top.Layout, top.Activations);
                break;
            case IR.Tensors.Prod top:
                Emitter.T.Prod();
                break;
            case IR.Tensors.Range top:
                Emitter.T.Range();
                break;
            case IR.Tensors.Reshape top:
                Emitter.T.Reshape();
                break;
            case IR.Tensors.ReverseSequence top:
                Emitter.T.ReverseSequence();
                break;
            case IR.Tensors.ScatterND top:
                Emitter.T.ScatterND();
                break;
            case IR.Tensors.ShapeOf top:
                Emitter.T.ShapeOf();
                break;
            case IR.Tensors.SizeOf top:
                Emitter.T.SizeOf();
                break;
            case IR.Tensors.Slice top:
                Emitter.T.Slice();
                break;
            case IR.Tensors.Split top:
                Emitter.T.Split();
                break;
            case IR.Tensors.Squeeze top:
                Emitter.T.Squeeze();
                break;
            case IR.Tensors.Stack top:
                Emitter.T.Stack();
                break;
            case IR.Tensors.Tile top:
                Emitter.T.Tile();
                break;
            case IR.Tensors.TopK top:
                Emitter.T.TopK();
                break;
            case IR.Tensors.Transpose top:
                Emitter.T.Transpose();
                break;
            case IR.Tensors.Unsqueeze top:
                Emitter.T.Unsqueeze();
                break;
            case IR.Tensors.Where top:
                Emitter.T.Where(top.IsTfWhere);
                break;
            case IR.Random.Normal top:
                Emitter.T.Normal(top.Type);
                break;
            case IR.Random.NormalLike top:
                Emitter.T.NormalLike(top.Type);
                break;
            case IR.Random.Uniform top:
                Emitter.T.Uniform(top.Type);
                break;
            case IR.Random.UniformLike top:
                Emitter.T.UniformLike(top.Type);
                break;
            case IR.Imaging.ResizeImage top:
                Emitter.T.ResizeImage(top.ResizeMode, top.TransformationMode, top.NearestMode, top.IsTFResize);
                break;
            default:
                throw new ArgumentException($"Unsupported op: {op}");
        }
    }
}
