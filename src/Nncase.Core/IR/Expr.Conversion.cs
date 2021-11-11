﻿// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics.Tensors;

namespace Nncase.IR
{
    /// <summary>
    /// Conversion of expression.
    /// </summary>
    public abstract partial record Expr
    {
        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="byte"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(byte value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(ushort value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="uint"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(uint value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(ulong value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="sbyte"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(sbyte value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="short"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(short value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="int"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(int value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="long"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(long value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="Half"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(Half value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="float"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(float value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="double"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(double value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="BFloat16"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(BFloat16 value) => (Const)value;

        /// <summary>
        /// Create <see cref="Expr"/> from a <see cref="bool"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        public static implicit operator Expr(bool value) => (Const)value;

        public static implicit operator Expr(Shape shape) => Const.FromShape(shape);

        public static implicit operator Expr(int[] span) => Const.FromSpan<int>(span);
        public static implicit operator Expr(float[] span) => Const.FromSpan<float>(span);

        public static implicit operator Expr(ReadOnlySpan<int> span) => Const.FromSpan<int>(span);

        public static implicit operator Expr(ReadOnlySpan<float> span) => Const.FromSpan<float>(span);

        public static implicit operator Expr(DenseTensor<int> tensor) => Const.FromTensor<int>(tensor);

        public static implicit operator Expr(DenseTensor<float> tensor) => Const.FromTensor<float>(tensor);
    }
}