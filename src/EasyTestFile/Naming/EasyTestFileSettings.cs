namespace EasyTestFile
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public partial class EasyTestFileSettings
    {
        public string? Directory { get; internal set; }

        /// <summary>
        /// Use a custom directory for the test files.
        /// </summary>
        public void UseDirectory(string directory)
        {
            Guard.BadDirectoryName(directory, nameof(directory));
            Directory = directory;
        }

        private string? _methodName;

        /// <summary>
        /// Use a custom method name for the testfiles.
        /// Where the file format is `{Directory}/{TestClassName}.{TestMethodName}_{Parameters}_{UniqueFor1}_{UniqueFor2}_{UniqueForX}.verified.{extension}`.
        /// </summary>
        /// <remarks>Not compatible with <see cref="UseFileName"/>.</remarks>
        public void UseMethodName(string name)
        {
            Guard.BadFileName(name, nameof(name));
            ThrowIfFileNameDefined();

            _methodName = name;
        }

        internal string? FileName;

        /// <summary>
        /// Use a file name for the test results.
        /// Overrides the `{TestClassName}.{TestMethodName}_{Parameters}` parts of the file naming.
        /// Where the file format is `{Directory}/{TestClassName}.{TestMethodName}_{Parameters}_{UniqueFor1}_{UniqueFor2}_{UniqueForX}.verified.{extension}`.
        /// </summary>
        public void UseFileName(string fileName)
        {
            // Guard.BadFileName(fileName, nameof(fileName));

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var firstChar = fileName[0];
            if (new List<char> {' ', '\\', '/'}.Contains(firstChar))
            {
                throw new ArgumentException("Invalid first char as filename");
            }

            if (fileName.EndsWith(" "))
            {
                throw new ArgumentException("Invalid last char as filename");
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            this.FileName = fileName;
        }

        void ThrowIfFileNameDefined([CallerMemberName] string caller = "")
        {
            if (FileName is not null)
            {
                throw new Exception($"{caller} is not compatible with {nameof(UseFileName)}.");
            }
        }
    }
}
