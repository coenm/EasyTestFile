namespace EasyTestFile;

using System;
using System.IO;
using System.Reflection;
using EasyTestFile.Internals;

/// <summary>
/// TestFile container.
/// </summary>
public sealed class TestFile
{
    private readonly EasyTestFileSettings _settings;
    private readonly Assembly _assembly;
    private readonly string _filenamePrefix;
    private readonly string _relativeDirectory;
    private readonly string _absoluteDirectory;

    internal TestFile(
        EasyTestFileSettings? settings,
        TestAssemblyInfo testAssemblyInfo,
        TestMethodInfo testMethodInfo)
    {
        _settings = settings ?? new EasyTestFileSettings();
        _assembly = _settings.Assembly ?? testAssemblyInfo.Assembly;

        _filenamePrefix = FileNameResolver.GetFileNamePrefix(_settings, testAssemblyInfo, testMethodInfo);
        (_relativeDirectory, _absoluteDirectory) = FileNameResolver.GetDirectories(_settings, testAssemblyInfo, testMethodInfo);
    }

    /// <summary>
    /// Read the TestFile as a <see cref="Stream"/>.
    /// </summary>
    /// <returns>Returns a read-only <see cref="Stream"/> if exists.</returns>
    /// <exception cref="TestFileNotFoundException">Thrown when stream cannot be found.</exception>
    public Stream AsStream()
    {
        var filename = _filenamePrefix + EasyTestFileConstants.EASY_TEST_FILE_SUFFIX + "." + _settings.ExtensionOrTxt();
        var relativeFilename = DirectorySanitizer.PathCombine(_relativeDirectory, filename);
        var physicalFilename = DirectorySanitizer.PathCombine(_absoluteDirectory, filename);

        Stream? stream =  StreamResolver.Resolve(relativeFilename, physicalFilename, _assembly);

        if (stream != null)
        {
            return stream;
        }
        
        var operatingSystemFullFilename = DirectorySanitizer.ToOperatingSystemPath(physicalFilename);
        var created = false;

        if (!_settings.AutoCreateMissingTestFileDisabled)
        {
            try
            {
                var dir = new FileInfo(operatingSystemFullFilename).DirectoryName;

                if (dir != null)
                {
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    File.Create(operatingSystemFullFilename);
                    created = true;
                }
            }
            catch (Exception exception)
            {
                throw new TestFileNotFoundException(operatingSystemFullFilename, created, exception);
            }
        }

        throw new TestFileNotFoundException(operatingSystemFullFilename, created);
    }

    internal EasyTestFileSettings GetSettings()
    {
        return _settings;
    }
}