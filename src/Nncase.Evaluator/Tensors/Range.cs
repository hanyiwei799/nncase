// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using Nncase.IR;
using OrtKISharp;
using Range = Nncase.IR.Tensors.Range;

namespace Nncase.Evaluator.Tensors;

/// <summary>
/// Evaluator for <see cref="Range"/>.
/// </summary>
public class RangeEvaluator : IEvaluator<Range>, ITypeInferencer<Range>
{
    /// <inheritdoc/>
    public IValue Visit(IEvaluateContext context, Range range)
    {
        var begin = context.GetOrtArgumentValue(range, Range.Begin);
        var end = context.GetOrtArgumentValue(range, Range.End);
        var step = context.GetOrtArgumentValue(range, Range.Step);
        return OrtKI.Range(begin, end, step).ToValue();
    }

    /// <inheritdoc/>
    public IRType Visit(ITypeInferenceContext context, Range target)
    {
        if (context.GetArgument(target, Range.Begin) is TensorConst beginValue
            && context.GetArgument(target, Range.End) is TensorConst endValue
            && context.GetArgument(target, Range.Step) is TensorConst stepValue)
        {
            if (beginValue.CheckedDataType == endValue.CheckedDataType &&
                endValue.CheckedDataType == stepValue.CheckedDataType)
            {
                return new TensorType(
                    DataTypes.Int64,
                    new Shape((beginValue.Value.ToScalar<int>() + endValue.Value.ToScalar<int>()) /
                              stepValue.Value.ToScalar<int>()));
            }
            else
            {
                return new InvalidType($"Range Begin End Step must be same type, " +
                                       $"but get begin:{beginValue.CheckedDataType}," +
                                       $"end:{endValue.CheckedDataType}," +
                                       $"step:{stepValue.CheckedDataType}");
            }
        }

        return new InvalidType("Range begin, end, step should be constant");
    }
}