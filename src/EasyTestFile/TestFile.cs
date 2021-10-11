namespace EasyTestFile
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;

    public sealed class TestFile
    {
        private readonly EasyTestFileSettings _settings;
        private readonly Assembly _assembly;
        private readonly string _physicalFilename;
        private readonly string _relativeFilename;
        private readonly TestAssemblyInfo _testAssemblyInfo;
        private readonly TestMethodInfo _testMethodInfo;

        public TestFile(
            EasyTestFileSettings? settings,
            TestAssemblyInfo testAssemblyInfo,
            TestMethodInfo testMethodInfo)
        {
            _settings = settings ?? new EasyTestFileSettings();
            _testAssemblyInfo = testAssemblyInfo;
            _testMethodInfo = testMethodInfo;
            _assembly = _settings.Assembly ?? _testAssemblyInfo.Assembly;

            // tmp
            _physicalFilename = _testMethodInfo.SourceFile;
            if (_physicalFilename.EndsWith(".cs"))
            {
                _physicalFilename = _physicalFilename[..(_testMethodInfo.SourceFile.Length - 3)];
            }

            var extension = _settings.ExtensionOrTxt();

            var suffix = string.Empty;
            if (!string.IsNullOrWhiteSpace(_settings.TestFileNamingSuffix))
            {
                suffix = "." + _settings.TestFileNamingSuffix;
            }

            var dotTestFileSuffix = string.Empty;
            if (_settings.UseDotTestFileSuffix)
            {
                dotTestFileSuffix = ".testfile";
            }

            _physicalFilename = _physicalFilename + "_" + _testMethodInfo.Method + suffix + dotTestFileSuffix + "." + extension;

            if (!string.IsNullOrWhiteSpace(_settings.FileName))
            {
                if (string.IsNullOrWhiteSpace(_settings.BaseDirectory))
                {
                    var xx = _testMethodInfo.SourceFileInfo!.Directory.FullName;
                    _physicalFilename = Path.Combine(xx, _settings.FileName!);
                }
                else
                {
                    _physicalFilename = Path.Combine(_testAssemblyInfo.ProjectDirectory, _settings.FileName!);
                }
            }


            if (string.IsNullOrWhiteSpace(_settings.BaseDirectory))
            {

                _relativeFilename = StringReplaceIgnoreCase(_physicalFilename, _testAssemblyInfo.ProjectDirectory, string.Empty);
            }
            else
            {
                _relativeFilename = StringReplaceIgnoreCase(_physicalFilename, _testAssemblyInfo.ProjectDirectory, string.Empty);
                _relativeFilename = Path.Combine(_settings.BaseDirectory!, _relativeFilename);
                _physicalFilename = StringReplaceIgnoreCase(_physicalFilename, _testAssemblyInfo.ProjectDirectory, Path.Combine(_testAssemblyInfo.ProjectDirectory, _settings.BaseDirectory!) + Path.DirectorySeparatorChar);
            }
        }

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
                    if (!_settings.disableAutoCreateMissingTestFile)
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

        public async Task<string> AsText()
        {
            Stream stream = AsStream();
            using var sr = new StreamReader(stream);
            return await sr.ReadToEndAsync().ConfigureAwait(false);
        }

        private static string StringReplaceIgnoreCase(in string input, in string search, in string replace)
        {
#if NETSTANDARD2_0
            return System.Text.RegularExpressions.Regex.Replace(input, search, replace, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
#else
            return input.Replace(search, replace, StringComparison.InvariantCultureIgnoreCase);
#endif
        }
    }
}
