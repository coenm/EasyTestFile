namespace EasyTestFile;

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EasyTestFile.Internals;

/// <summary>
/// TestFile container.
/// </summary>
public sealed class TestFile
{
    private readonly EasyTestFileSettings _settings;
    private readonly Assembly _assembly;
    private readonly string _physicalFilename;
    private readonly string _relativeFilename;
    private readonly TestAssemblyInfo _testAssemblyInfo;
    private readonly TestMethodInfo _testMethodInfo;

    internal TestFile(
        EasyTestFileSettings? settings,
        TestAssemblyInfo testAssemblyInfo,
        TestMethodInfo testMethodInfo)
    {
        _settings = settings ?? new EasyTestFileSettings();
        _testAssemblyInfo = testAssemblyInfo;
        _testMethodInfo = testMethodInfo;
        _assembly = _settings.Assembly ?? _testAssemblyInfo.Assembly;

        (_relativeFilename, _physicalFilename) = FileNameResolver.Find(_settings, _testAssemblyInfo, _testMethodInfo);
    }

    /// <summary>
    /// Read the TestFile as a <see cref="Stream"/>.
    /// </summary>
    /// <returns>Returns a read-only <see cref="Stream"/> if exists.</returns>
    /// <exception cref="TestFileNotFoundException">Thrown when stream cannot be found.</exception>
    public Stream AsStream()
    {
        //todo make case insensitive
        var fileName = _relativeFilename;
        fileName = fileName.Replace('\\', '/');

        Stream? stream = _assembly.GetManifestResourceStream(fileName);

        if (stream == null)
        {
            fileName = fileName.TrimStart(new[] { '/', '\\' });
            stream = _assembly.GetManifestResourceStream(fileName);
        }

        if (stream == null)
        {
            fileName = _relativeFilename;
            fileName = fileName.Replace('/', '\\');
            stream = _assembly.GetManifestResourceStream(fileName);
        }

        if (stream == null)
        {
            fileName = fileName.TrimStart(new[] { '/', '\\' });
            stream = _assembly.GetManifestResourceStream(fileName);
        }

        if (stream == null)
        {
            if (!string.IsNullOrWhiteSpace(_physicalFilename) && File.Exists(_physicalFilename))
            {
                stream = File.OpenRead(_physicalFilename);
            }
        }

        var created = false;
        if (stream == null)
        {
            // create file
            if (!string.IsNullOrWhiteSpace(_physicalFilename))
            {
                if (!_settings.AutoCreateMissingTestFileDisabled)
                {
                    var dir = new FileInfo(_physicalFilename).DirectoryName;

                    if (dir != null)
                    {
                        if (!Directory.Exists(dir))
                        {
                            _ = Directory.CreateDirectory(dir);
                        }

                        _ = File.Create(_physicalFilename);
                        created = true;
                    }
                }
            }
        }

        if (stream == null)
        {
            throw new TestFileNotFoundException(_physicalFilename, created);
        }

        return stream;
    }
}