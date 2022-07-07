﻿// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nncase.IR;

/// <summary>
/// Function interface.
/// </summary>
public interface IFunction
{
    /// <summary>
    /// Gets parameter types.
    /// </summary>
    IEnumerable<IRType?> ParameterTypes { get; }
}

/// <summary>
/// the Callable Expr
/// </summary>
public abstract record Callable(string Name, string ModuleKind) : Expr
{
    /// <summary>
    /// StackVM module kind.
    /// </summary>
    public static readonly string StackVMModuleKind = "stackvm";

    /// <summary>
    /// the schedule result, the dag function for stackvm, the prim_func for other backend.
    /// </summary>
    public Schedule.SchedFunctionResult? SchedResult = null;
}

/// <summary>
/// Function expression.
/// </summary>
public record Function(string Name, Expr Body, IRArray<Var> Parameters) : Callable(Name, StackVMModuleKind), IFunction
{
    private static int _globalFuncIndex = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Function"/> class.
    /// </summary>
    /// <param name="parameters">Parameters.</param>
    /// <param name="body">Body.</param>
    public Function(Expr body, IRArray<Var> parameters)
        : this($"func_{_globalFuncIndex++}", body, parameters)
    {
    }

    /// <summary>
    /// build function.
    /// </summary>
    /// <param name="body"></param>
    /// <param name="parameters"></param>
    public Function(Expr body, params Var[] parameters)
        : this($"func_{_globalFuncIndex++}", body, new(parameters))
    {
    }

    IEnumerable<IRType?> IFunction.ParameterTypes => Parameters.Select(x => x.CheckedType);
}
