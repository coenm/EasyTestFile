namespace EasyTestFile;

using System;
using System.IO;
using System.Reflection;
using EasyTestFile.Internals;

internal readonly struct TestMethodInfo
{
    /// <exception cref="ArgumentNullException">Thrown when a parameter is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a parameter contains an invalid value..</exception>
    /// <exception cref="Exception">Thrown when something else goes wrong.</exception>
    internal TestMethodInfo(MethodInfo info, string sourceFile, string method) :
        this(sourceFile, method)
    {
        _ = info;
    }

    /// <exception cref="ArgumentNullException">Thrown when a parameter is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a parameter contains an invalid value..</exception>
    /// <exception cref="Exception">Thrown when something else goes wrong.</exception>
    private TestMethodInfo(string sourceFile, string method)
    {
        Guard.AgainstBadMethodName(method, nameof(method));
        Guard.BadDirectoryName(sourceFile, nameof(sourceFile));

        FileInfo? fi;

        try
        {
            fi = new FileInfo(sourceFile);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"FileInfo creation failed with value '{sourceFile}'", sourceFile, e);
        }

        var dirName = fi!.Directory?.FullName ?? string.Empty;

        if (string.IsNullOrEmpty(dirName))
        {
            throw new Exception("Could not determine directory.");
        }

        dirName = dirName.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        SanitizedDirectory = DirectorySanitizer.Sanitize(dirName);
        SanitizedFullSourceFile = DirectorySanitizer.Sanitize(sourceFile);

        if (fi!.Name.Length >= fi!.Extension.Length && fi!.Name.EndsWith(fi!.Extension))
        {
            FileName = fi!.Name.Substring(0, fi!.Name.Length - fi!.Extension.Length);
        }
        else
        {
            FileName = fi!.Name;
        }
        
        Method = method;
    }

    /// <summary>
    /// Filename without extension.
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Caller full filename with '\' path separators.
    /// </summary>
    public string SanitizedFullSourceFile { get; }

    /// <summary>
    /// Caller full directory with '\' path separators. Ends with '\'.
    /// </summary>
    public string SanitizedDirectory { get; }

    /// <summary>
    /// Caller method name.
    /// </summary>
    public string Method { get; }
}