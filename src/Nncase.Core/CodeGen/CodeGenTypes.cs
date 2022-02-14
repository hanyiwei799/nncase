// Copyright (c) Canaan Inc. All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Nncase.IR;

namespace Nncase.CodeGen;

/// <summary>
/// The CodeGen Model Information.
/// </summary>
public static class ModelInfo
{
    /// <summary>
    /// Gets model identifier.
    /// </summary>
    public static uint Identifier => BitConverter.ToUInt32(Encoding.UTF8.GetBytes("KMDL"), 0);

    /// <summary>
    /// Gets model version.
    /// </summary>
    public static uint Version => 5;

    public const uint SECTION_MERGED_INTO_RDATA = 1;

    public const uint MaxSectionNameLength = 16;

    public const uint MaxModuleTypeLength = 16;
}

/// <summary>
/// the module type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ModuleType
{
    char[] Types = new char[ModelInfo.MaxModuleTypeLength];

    /// <summary>
    /// create the modult type by name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static ModuleType Create(string name)
    {
        var mt = new ModuleType();
        for (int i = 0; i < ModelInfo.MaxModuleTypeLength; i++)
        {
            mt.Types[i] = i < name.Length ? name[i] : '\0';
        }

        return mt;
    }
}

/// <summary>
/// the runtime function.
/// </summary>
public interface IRTFunction
{
    /// <summary>
    /// the funtion name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// the function pointer handle.
    /// </summary>
    public Delegate Handle { get; set; }
}

/// <summary>
/// when model or module has been Serialized. return the result.
/// </summary>
public interface ISerializeResult
{
}

/// <summary>
/// runtime module.
/// </summary>
public interface IRTModule
{
    /// <summary>
    /// the Module type.
    /// </summary>
    public ModuleType ModuleType { get; set; }

    /// <summary>
    /// get source code.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// get source file ext.
    /// </summary>
    public string SourceExt { get; set; }

    /// <summary>
    /// dump the source into file `DumpDirPath/name.xx`.
    /// </summary>
    /// <param name="name">file name. </param>
    /// <param name="dumpDirPath"> dump dir path. </param>
    public void Dump(string name, string dumpDirPath);

    /// <summary>
    /// Serialize the code.
    /// </summary>
    public ISerializeResult Serialize();

    /// <summary>
    /// get the all runtime function.
    /// </summary>
    public IReadOnlyList<IRTFunction> Functions { get; }
}

/// <summary>
/// The runtime Model.
/// <example>
/// Runtime Model ∈ {
///     RTModule1 ∈ { RTFuntion1, RTFuntion2 ... } ,
///     RTModule2 ...}
/// </example>
/// </summary>
public interface IRTModel
{
    /// <summary>
    /// the target.
    /// </summary>
    public ITarget Target { get; set; }

    /// <summary>
    /// schedule result.
    /// </summary>
    public Schedule.SchedModelResult modelResult { get; set; }

    /// <summary>
    /// get source code.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// get source file ext.
    /// </summary>
    public string SourceExt { get; set; }

    /// <summary>
    /// dump the source into file `DumpDirPath/name.xx`.
    /// </summary>
    /// <param name="name">file name. </param>
    /// <param name="dumpDirPath"> dump dir path. </param>
    public void Dump(string name, string dumpDirPath);

    /// <summary>
    /// Serialize the runtime model.
    /// <example>
    /// if this runtime model is kmodel, will serialize as kmodel.
    /// if is Csource, will serialize as .c file.
    /// </example>
    /// </summary>
    public ISerializeResult Serialize();

    /// <summary>
    /// call this runtime model.
    /// </summary>
    /// <param name="args"> input args.</param>
    /// <returns></returns>
    public object? Invoke(params object?[]? args);

    /// <summary>
    /// get runtime function entry.
    /// </summary>
    public IRTFunction? Entry { get; }

    /// <summary>
    /// get the all runtime function.
    /// </summary>
    public IReadOnlyList<IRTModule> Modules { get; }
}