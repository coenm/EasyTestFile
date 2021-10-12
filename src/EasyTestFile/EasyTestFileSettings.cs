namespace EasyTestFile
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    public partial class EasyTestFileSettings
    {
        public EasyTestFileSettings()
        {
        }

        public EasyTestFileSettings(EasyTestFileSettings? settings)
        {
            if (settings is null)
            {
                return;
            }

            _extension = settings._extension;
            disableAutoCreateMissingTestFile = settings.disableAutoCreateMissingTestFile;

            FileName = settings.FileName;
            BaseDirectory = settings.BaseDirectory;
            TestFileNamingSuffix = settings.TestFileNamingSuffix;
            UseDotTestFileSuffix = settings.UseDotTestFileSuffix;
        }

        internal bool disableAutoCreateMissingTestFile = false;

        /// <summary>
        /// Disable the creation of an empty test file when the file could not have been found.
        /// </summary>
        public void DisableAutoCreateMissingTestFile()
        {
             disableAutoCreateMissingTestFile = true;
        }
        
        internal string? BaseDirectory;

        public void UseBaseDirectory(string path)
        {
            // todo input validation
            BaseDirectory = path;
        }


        public void UseEasyTestFileBaseDirectory()
        {
            UseBaseDirectory("EasyTestFiles"); // todo, multiple
        }
        

        internal string? TestFileNamingSuffix;

        public void UseArgument(int input)
        {
            UseArgument($"{input}");
        }

        public void UseArgument(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            TestFileNamingSuffix = input.Trim();
        }
        
        internal bool UseDotTestFileSuffix = true;

        public void WithoutDotTestFileSuffix()
        {
            UseDotTestFileSuffix = false;
        }
        
        internal Assembly? Assembly = null;

        /// <summary>
        /// Specify the assembly containing the testfile.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public void UseAssembly(Assembly assembly)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }
    }
}
