namespace EasyTestFile
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public partial class EasyTestFileSettings
    {
        internal string? FileName;

        /// <summary>
        /// Use a file name for the test results.
        /// Overrides the `{TestClassName}.{TestMethodName}_{Parameters}` parts of the file naming.
        /// Where the file format is `{Directory}/{TestClassName}.{TestMethodName}_{Parameters}_{UniqueFor1}_{UniqueFor2}_{UniqueForX}.verified.{extension}`.
        /// </summary>
        public void UseFileName(string fileName)
        {
            // Guard.BadFileName(fileName, nameof(fileName));
            if (fileName == null)
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
    }
}
