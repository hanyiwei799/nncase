﻿// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nncase.IR;
using Nncase.TIR;

namespace Nncase.Transform;

/// <summary>
/// the static mutator can create the mutator in the tir pass.
/// </summary>
public static class Mutator
{
    /// <summary>
    /// Unroll Loop.
    /// </summary>
    public static Func<ExprMutator> UnRollLoopSequential() => () => new Mutators.UnRollLoopSequential();

    /// <summary>
    /// fold let when expression is const.
    /// </summary>
    public static Func<ExprMutator> FoldLet() => () => new Mutators.FoldLet();

    /// <summary>
    /// unfold block statements.
    /// </summary>
    public static Func<ExprMutator> UnFoldBlock() => () => new Mutators.UnFoldBlock();

    /// <summary>
    /// fold const tuple to tupleconst.
    /// </summary>
    public static Func<ExprMutator> FoldConstTuple() => () => new Mutators.FoldConstTuple();

    /// <summary>
    /// flatten the sequential.
    /// </summary>
    public static Func<ExprMutator> FlattenSequential() => () => new Mutators.FlattenSequential();

    /// <summary>
    /// substitute.
    /// </summary>
    public static Func<ExprMutator> Substitute(Func<Expr, Expr?> maper) => () => new Mutators.Substitutor(maper);

    /// <summary>
    /// fold if then else block.
    /// </summary>
    public static Func<ExprMutator> FoldIfThen() => () => new Mutators.FoldIfThen();

    /// <summary>
    /// 删除内部的T.Nop.
    /// </summary>
    /// <returns>RemoveNop.</returns>
    public static Func<ExprMutator> RemoveNop() => () => new Mutators.RemoveNop();

    /// <summary>
    /// fold math calc operator.
    /// </summary>
    /// <returns>FoldMathCall.</returns>
    public static Func<ExprMutator> FoldMathCall() => () => new Mutators.FoldMathCall();
}