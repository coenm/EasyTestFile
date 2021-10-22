namespace EasyTestFile;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EasyTestFile.Internals;

public partial class EasyTestFileSettings
{
    /// <summary>
    /// Base directory after the project directory.
    /// </summary>
    internal string? BaseDirectory;

    /// <summary>
    /// Set base directory for the test files. The path is relative to the {project path}. I.e. '<c>MyData\MyTestData</c>' results in '<c>{project path}\MyData\MyTestData</c>'.
    /// </summary>
    /// <param name="path">The path of the base directory.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is <c>null</c>.</exception>
    public EasyTestFileSettings UseBaseDirectory(string path)
    {
        Guard.AgainstNullOrEmpty(path, nameof(path));
        BaseDirectory = path;
        return this;
    }

    /// <summary>
    /// Use '{project path}\EasyTestFiles' as base directory for the test files.
    /// </summary>
    public EasyTestFileSettings UseEasyTestFileBaseDirectory()
    {
        return UseBaseDirectory(EasyTestFileConstants.EASY_TEST_FILE_FOLDER);
    }
}