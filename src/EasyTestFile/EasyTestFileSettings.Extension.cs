namespace EasyTestFile;

using System;

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

    internal string ExtensionOrDefault(string defaultValue)
    {
        return _extension ?? defaultValue;
    }

    internal string ExtensionOrTxt()
    {
        return ExtensionOrDefault("txt");
    }
}