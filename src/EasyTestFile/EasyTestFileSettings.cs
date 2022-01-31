namespace EasyTestFile;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

/// <summary>
/// Settings for EasyTestFile
/// </summary>
public partial class EasyTestFileSettings
{
    /// <summary>
    /// Creates default settings
    /// </summary>
    public EasyTestFileSettings()
    {
    }

    /// <summary>
    /// Creates settings based on <paramref name="settings"/>.
    /// </summary>
    public EasyTestFileSettings(EasyTestFileSettings? settings)
    {
        if (settings is null)
        {
            return;
        }

        _extension = settings._extension;
        FileName = settings.FileName;
        Directory = settings.Directory;
        MethodName = settings.MethodName;
        AutoCreateMissingTestFileDisabled = settings.AutoCreateMissingTestFileDisabled;
        TestFileNamingSuffix = settings.TestFileNamingSuffix;
        Assembly = settings.Assembly;

        foreach (KeyValuePair<string, object> pair in settings.Context)
        {
            if (pair.Value is ICloneable cloneable)
            {
                Context.Add(pair.Key, cloneable.Clone());
            }
            else
            {
                Context.Add(pair.Key, pair.Value);
            }
        }
    }

    internal bool AutoCreateMissingTestFileDisabled = false;

    /// <summary>
    /// Allows extensions to EasyTestFile to pass config via <see cref="EasyTestFileSettings"/>.
    /// </summary>
    public Dictionary<string, object> Context { get; } = new();
    
    /// <summary>
    /// Disable the creation of an empty test file when the file could not have been found.
    /// </summary>
    public void DisableAutoCreateMissingTestFile()
    {
        AutoCreateMissingTestFileDisabled = true;
    }
        
    internal string? TestFileNamingSuffix;

    /// <summary>
    /// Use <paramref name="input"/>  as suffix for naming the testfile.
    /// In this case, the testfile will be named `{Directory}/{TestClassName}.{TestMethodName}{Suffix}.testfile.{extension}`.
    /// </summary>
    /// <param name="input">The suffix.</param>
    public void SetTestFileNameSuffix(int input)
    {
        SetTestFileNameSuffix($"{input}");
    }

    /// <summary>
    /// Use <paramref name="input"/> as suffix for naming the testfile.
    /// In this case, the testfile will be named `{Directory}/{TestClassName}.{TestMethodName}_{Suffix}.testfile.{extension}`.
    /// </summary>
    /// <param name="input">The suffix.</param>
    /// <exception cref="ArgumentNullException">Throw when argument is <c>null</c> or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when argument has invalid characters.</exception>
    public void SetTestFileNameSuffix(string input)
    {
        Guard.BadFileName(input, nameof(input));
        TestFileNamingSuffix = input.Trim();
    }
        
    internal Assembly? Assembly = null;

    /// <summary>
    /// Specify the assembly containing the testfile. This is only required when the running test is in an other assembly then the testfile.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> is <c>null</c>.</exception>
    public void UseAssembly(Assembly assembly)
    {
        Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
    }
}