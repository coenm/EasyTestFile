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
    
    internal TestFile(
        EasyTestFileSettings? settings,
        TestAssemblyInfo testAssemblyInfo,
        TestMethodInfo testMethodInfo)
    {
        _settings = settings ?? new EasyTestFileSettings();
        _assembly = _settings.Assembly ?? testAssemblyInfo.Assembly;

        (_relativeFilename, _physicalFilename) = FileNameResolver.Find(_settings, testAssemblyInfo, testMethodInfo);
    }

    /// <summary>
    /// Read the TestFile as a <see cref="Stream"/>.
    /// </summary>
    /// <returns>Returns a read-only <see cref="Stream"/> if exists.</returns>
    /// <exception cref="TestFileNotFoundException">Thrown when stream cannot be found.</exception>
    public Stream AsStream()
    {
        Stream? stream =  StreamResolver.Resolve(_relativeFilename, _physicalFilename, _assembly);

        if (stream != null)
        {
            return stream;
        }
        
        var operatingSystemFullFilename = DirectorySanitizer.ToOperatingSystemPath(_physicalFilename);
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
}