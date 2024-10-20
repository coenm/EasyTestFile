namespace EasyTestFileTUnit
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using EasyTestFileTUnit.Internal;
    using global::EasyTestFile;

    /// <summary>
    /// EasyTestFile
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument", Justification = "Intentional")]
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
            var callingAssembly = Assembly.GetCallingAssembly();
            return TestFileFactory.Create(callingAssembly, settings, sourceFile, method);
        }

        /// <summary>
        /// Load a test file as text.
        /// </summary>
        /// <param name="settings">Settings, optional, default value is <c>null</c>.</param>
        /// <param name="sourceFile">The source filename, should not be overridden. Default value is <c>[CallerFilePath]</c>.</param>
        /// <param name="method">The caller, (normally the test method). Should not be overridden. Default value is <c>CallerMemberName</c>.</param>
        /// <returns>The text content of the test file.</returns>
        public static Task<string> LoadAsText(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            TestFile testFile = TestFileFactory.Create(callingAssembly, settings, sourceFile, method);
            return testFile.AsText();
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
            var callingAssembly = Assembly.GetCallingAssembly();
            TestFile testFile = TestFileFactory.Create(callingAssembly, settings, sourceFile, method);
            return testFile.AsStream();
        }
    }
}
