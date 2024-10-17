// ReSharper disable once CheckNamespace
namespace EasyTestFile;

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

/// <summary>
/// Exception when TestFile cannot be found.
/// </summary>
public sealed class TestFileNotFoundException : Exception
{
    internal TestFileNotFoundException(string filename, bool created)
        : base(CreateExceptionMessage(filename, created))
    {
        Filename = filename;
        TestFileCreated = created;
    }

    internal TestFileNotFoundException(string filename, bool created, Exception innerException)
        : base(CreateExceptionMessage(filename, created), innerException)
    {
        Filename = filename;
        TestFileCreated = created;
    }

    /// <summary>
    /// Name of the missing filename.
    /// </summary>
    public string Filename { get; private set; }

    /// <summary>
    /// Boolean specifying if the TestFile was created. If so, the path of the filename is visible through the <seealso cref="Filename"/> property.
    /// </summary>
    public bool TestFileCreated { get; private set; }

    private static string CreateExceptionMessage(string filename, bool created)
    {
        return created
            ? $"TestFile '{filename}' didn't exist but was created."
            : $"TestFile '{filename}' didn't exist. Please create the file yourself.";
    }
}