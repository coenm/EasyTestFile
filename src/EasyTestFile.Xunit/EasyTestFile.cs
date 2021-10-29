namespace EasyTestFileXunit
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using EasyTestFileNunit.Internal;
    using global::EasyTestFile;

    /// <summary>
    /// EasyTestFile
    /// </summary>
    public static partial class EasyTestFile
    {
        /// <summary>
        /// Load a test file
        /// </summary>
        /// <param name="settings">Settings, optional, default value is <c>null</c>.</param>
        /// <param name="sourceFile">The source filename, should not be overridden. Default value is <c>[CallerFilePath]</c>.</param>
        /// <param name="method">The caller, (normally the test method). Should not be overridden. Default value is <c>CallerMemberName</c>.</param>
        /// <returns>An instance of <see cref="TestFile"/>.</returns>
        public static TestFile Load(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            return TestFileFactory.Create(settings, sourceFile, method);
        }

        /// <summary>
        /// Load a test file as text.
        /// </summary>
        /// <param name="settings">Settings, optional, default value is <c>null</c>.</param>
        /// <param name="sourceFile">The source filename, should not be overridden. Default value is <c>[CallerFilePath]</c>.</param>
        /// <param name="method">The caller, (normally the test method). Should not be overridden. Default value is <c>CallerMemberName</c>.</param>
        /// <returns>The text content of the test file.</returns>
        public static async Task<string> LoadAsText(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            TestFile testFile = TestFileFactory.Create(settings, sourceFile, method);
            return await testFile.AsText();
        }

        /// <summary>
        /// Load a test file as a stream.
        /// </summary>
        /// <param name="settings">Settings, optional, default value is <c>null</c>.</param>
        /// <param name="sourceFile">The source filename, should not be overridden. Default value is <c>[CallerFilePath]</c>.</param>
        /// <param name="method">The caller, (normally the test method). Should not be overridden. Default value is <c>CallerMemberName</c>.</param>
        /// <returns>Returns the opened Stream of the test file.</returns>
        public static Task<Stream> LoadAsStream(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            TestFile testFile = TestFileFactory.Create(settings, sourceFile, method);
            return Task.FromResult(testFile.AsStream());
        }
    }

    public static partial class EasyTestFile
    {
        public static TestFile Load(
            string filename,
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var s = new EasyTestFileSettings(settings);
            s.UseFileName(filename);
            return Load(s, sourceFile, method);
        }

        public static Task<string> LoadAsText(
            string filename,
            EasyTestFileSettings? settings = null,
            [CallerFilePathAttribute] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var s = new EasyTestFileSettings(settings);
            s.UseFileName(filename);
            return LoadAsText(s, sourceFile, method);
        }

        public static Task<Stream> LoadAsStream(
            string filename,
            EasyTestFileSettings? settings = null,
            [CallerFilePathAttribute] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var s = new EasyTestFileSettings(settings);
            s.UseFileName(filename);
            return LoadAsStream(s, sourceFile, method);
        }
    }
}
