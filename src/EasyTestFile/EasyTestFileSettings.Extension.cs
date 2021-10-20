namespace EasyTestFile;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

public partial class EasyTestFileSettings
{
    private string? _extension;

    /// <summary>
    /// Use a custom file extension for the test file.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when argument is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when argument is not a valid extension.</exception>
    public EasyTestFileSettings UseExtension(string extension)
    {
        Guard.AgainstBadExtension(extension, nameof(extension));
        _extension = extension;
        return this;
    }

    /// <summary>
    /// Retrieves the value passed into <see cref="UseExtension"/>, if it exists.
    /// </summary>
    public bool TryGetExtension([NotNullWhen(true)] out string? extension)
    {
        if (_extension is null)
        {
            extension = null;
            return false;
        }

        extension = _extension;
        return true;
    }

    internal string ExtensionOrDefault(string defaultValue)
    {
        return _extension ?? defaultValue;
    }

    internal string ExtensionOrTxt()
    {
        return ExtensionOrDefault("txt");
    }
}