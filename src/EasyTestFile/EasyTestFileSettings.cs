namespace EasyTestFile
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    /// <summary>
    /// Settings for EasyTestFile
    /// </summary>
    public partial class EasyTestFileSettings
    {
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public EasyTestFileSettings()
        {
        }

        /// <summary>
        /// Creates EasyTestFileSettings based on <paramref name="settings"/>.
        /// </summary>
        public EasyTestFileSettings(EasyTestFileSettings? settings)
        {
            if (settings is null)
            {
                return;
            }

            _extension = settings._extension;
            AutoCreateMissingTestFileDisabled = settings.AutoCreateMissingTestFileDisabled;

            FileName = settings.FileName;
            BaseDirectory = settings.BaseDirectory;
            TestFileNamingSuffix = settings.TestFileNamingSuffix;
            UseDotTestFileSuffix = settings.UseDotTestFileSuffix;
            Assembly = settings.Assembly;
        }

        internal bool AutoCreateMissingTestFileDisabled = false;

        /// <summary>
        /// Disable the creation of an empty test file when the file could not have been found.
        /// </summary>
        public void DisableAutoCreateMissingTestFile()
        {
             AutoCreateMissingTestFileDisabled = true;
        }
        
        internal string? TestFileNamingSuffix;

        /// <summary>
        
        /// </summary>
        /// <param name="input"></param>
        public void SetTestFileNameSuffix(int input)
        {
            SetTestFileNameSuffix($"{input}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentNullException">Throw when argument is <c>null</c> or empty.</exception>
        public void SetTestFileNameSuffix(string input)
        {
            Guard.AgainstNullOrEmpty(input, nameof(input));
            TestFileNamingSuffix = input.Trim();
        }
        
        internal bool UseDotTestFileSuffix = true;

        public void WithoutDotTestFileSuffix()
        {
            UseDotTestFileSuffix = false;
        }
        
        internal Assembly? Assembly = null;

        /// <summary>
        /// Specify the assembly containing the testfile. This is only required when the running test is in an other assembly then the testfile.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> is <c>null</c>.</exception>
        public void UseAssembly(Assembly assembly)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }
    }
}
