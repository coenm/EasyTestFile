namespace EasyTestFileNunit;

using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using global::EasyTestFile;

/// <summary>
/// EasyTestFile
/// </summary>
public static class EasyTestFile
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
    public static Task<string> LoadAsText(
        EasyTestFileSettings? settings = null,
        [CallerFilePath] string sourceFile = "",
        [CallerMemberName] string method = "")
    {
        TestFile dataLoader = Load(settings, sourceFile, method);
        return dataLoader.AsText();
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
        TestFile dataLoader = Load(settings, sourceFile, method);
        return Task.FromResult(dataLoader.AsStream());
    }
}