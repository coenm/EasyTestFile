// ReSharper disable once CheckNamespace
namespace EasyTestFile;

using System;
using System.Reflection;
using System.Runtime.Serialization;

/// <summary>
/// Exception thrown when an expected AssemblyMetadataAttribute was not found.
/// </summary>
public sealed class AssemblyMetadataAttributeNotFoundException : Exception
{
    internal AssemblyMetadataAttributeNotFoundException(string assemblyName, string key)
    {
        AssemblyName = assemblyName;
        Key = key;
    }

    /// <summary>
    /// Name of the Assembly.
    /// </summary>
    public string AssemblyName { get; private set; }

    /// <summary>
    /// Missing key.
    /// </summary>
    public string Key { get; private set; }
    
    /// <inheritdoc />
    public override string ToString()
    {
        return $"Could not find an `AssemblyMetadataAttribute` named `{Key}` in assembly `{AssemblyName}`.";
    }
}