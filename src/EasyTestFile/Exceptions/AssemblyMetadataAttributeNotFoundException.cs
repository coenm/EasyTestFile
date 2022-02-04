// ReSharper disable once CheckNamespace
namespace EasyTestFile;

using System;
using System.Reflection;
using System.Runtime.Serialization;

/// <summary>
/// Exception thrown when an expected AssemblyMetadataAttribute was not found.
/// </summary>
[Serializable]
public sealed class AssemblyMetadataAttributeNotFoundException : Exception
{
    internal AssemblyMetadataAttributeNotFoundException(string assemblyName, string key)
    {
        AssemblyName = assemblyName;
        Key = key;
    }

    private AssemblyMetadataAttributeNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        AssemblyName = info.GetString("AssemblyName")!;
        Key = info.GetString("Key")!;
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
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null)
        {
            throw new ArgumentNullException(nameof(info));
        }

        info.AddValue("AssemblyName", AssemblyName);
        info.AddValue("Key", Key);

        base.GetObjectData(info, context);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Could not find an `AssemblyMetadataAttribute` named `{Key}` in assembly `{AssemblyName}`.";
    }
}