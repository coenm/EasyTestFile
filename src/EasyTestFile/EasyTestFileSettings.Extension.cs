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

    /// <summary>
    /// Custom directory for test files.
    /// </summary>
    public string? Directory { get; internal set; }

    /// <summary>
    /// Use a custom directory for the test file.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when argument is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when argument is not a valid directory.</exception>
    public EasyTestFileSettings UseDirectory(string directory)
    {
        Guard.BadDirectoryName(directory, nameof(directory));
        Directory = directory;
        return this;
    }

    internal string? MethodName;

    /// <summary>
    /// Use a custom method name for the testfile.
    /// Where the file format is `{Directory}/{TestClassName}.{TestMethodName}_{Parameters}.testfile.{extension}`.
    /// </summary>
    /// <remarks>Not compatible with <see cref="UseFileName"/>.</remarks>
    public void UseMethodName(string name)
    {
        Guard.BadFileName(name, nameof(name));
        /* ThrowIfFileNameDefined()*/

        MethodName = name;
    }

    internal string? FileName;

    /// <summary>
    /// Use a file name for the test file.
    /// Overrides the `{TestClassName}.{TestMethodName}{Suffix}` parts of the file naming.
    /// Where the file format is `{Directory}/{TestClassName}.{TestMethodName}{Suffix}.testfile.{extension}`.
    /// </summary>
    /// <remarks>Not compatible with <see cref="UseMethodName"/>, or <see cref="SetTestFileNameSuffix(string)"/>.</remarks>
    public void UseFileName(string fileName)
    {
        Guard.BadFileName(fileName, nameof(fileName));
        // ThrowIfMethodOrTypeNameDefined()

        FileName = fileName;
    }
}