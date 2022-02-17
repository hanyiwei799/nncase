﻿// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nncase.IR.NN;
using Nncase.IR.Tensors;

namespace Nncase.IR.F
{
    /// <summary>
    /// NN functional helper.
    /// </summary>
    public static class NN
    {
        public static Call Conv2D(Expr input, Expr weights, Expr bias, Expr stride, Expr padding, Expr dilation, PadMode padMode, Expr groups) => new Call(new Conv2D(padMode), input, weights, bias, stride, padding, dilation, groups);

        public static Call Celu(Expr input, Expr alpha) => new Call(new Celu(), input, alpha);

        public static Call Conv2DTranspose(Expr input, Expr weights, Expr bias, Expr outShape, Expr stride, Expr padding, Expr dilation, PadMode padMode, Expr groups) => new Call(new Conv2DTranspose(padMode), input, weights, bias, outShape, stride, padding, dilation, groups);

        public static Call Elu(Expr input, Expr alpha) => new Call(new Elu(), input, alpha);

        public static Call Hardmax(Expr input, Expr axis) => new Call(new Hardmax(), input, axis);

        public static Call LeakyRelu(Expr input) => new Call(new LeakyRelu(), input);

        public static Call L2Normalization(Expr input) => new Call(new L2Normalization(), input);

        public static Call BatchNormalization(Expr input, Expr scale, Expr bias,
            Expr input_mean, Expr input_var, Expr epsilon, Expr momentum) => new Call(
            new BatchNormalization(), input, scale, bias, input_mean, input_var, epsilon, momentum);

        public static Call BatchToSpace(Expr input, Expr blockShape, Expr crops) => new Call(new BatchToSpace(), input, blockShape, crops);

        public static Call InstanceNormalization(Expr input, Expr eps) => new Call(new InstanceNormalization(), input, eps);

        public static Call LpNormalization(Expr input, Expr axis, Expr p) => new Call(new LpNormalization(), input, axis, p);

        public static Call LRN(Expr input, Expr alpha, Expr beta, Expr bias, Expr size) => new Call(new LRN(), input, alpha, beta, bias, size);

        public static Call HardSigmoid(Expr input, Expr alpha, Expr beta) => new Call(new HardSigmoid(), input, alpha, beta);

        public static Call HardSwish(Expr input) => new Call(new HardSwish(), input);

        public static Call OneHot(OneHotMode oneHotMode, Expr indices, Expr depth, Expr onValue, Expr offValue, Expr axis) => new Call(new OneHot(oneHotMode), indices, depth, onValue, offValue, axis);

        /// <summary>
        /// Pads is Const tensor, shape = [channels, 2(before, after)].
        /// </summary>
        public static Call Pad(Expr input, Expr pads, PadMode mode, Expr value) => new Call(new Pad(mode), input, pads, value);

        public static Call ReduceWindow2D(ReduceOp reduceOp, Expr input, Expr initValue, Expr filter, Expr stride, Expr padding, Expr ceilMode, Expr countIncludePad) =>
            new Call(new ReduceWindow2D(reduceOp), input, initValue, filter, stride, padding, ceilMode, countIncludePad);

        public static Call Relu(Expr input) => new Call(new Relu(), input);

        public static Call Relu6(Expr input) => new Call(new Relu6(), input);

        public static Call PRelu(Expr input) => new Call(new PRelu(), input);

        public static Call Selu(Expr input) => new Call(new Selu(), input);

        public static Call Sigmoid(Expr expr) => new Call(new Sigmoid(), expr);

        public static Call Softmax(Expr expr, Expr axis) => new Call(new Softmax(), expr, axis);

        public static Call Softplus(Expr expr) => new Call(new Softplus(), expr);

        public static Call Softsign(Expr expr) => new Call(new Softsign(), expr);

        // same like tensorflow
        public static Call SpaceToBatch(Expr input, Expr blockShape, Expr paddings) => new Call(new SpaceToBatch(), input, blockShape, paddings);

        public static Call LogSoftmax(Expr expr, Expr axis) => new Call(new LogSoftmax(), expr, axis);
    }
}