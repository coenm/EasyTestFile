namespace EasyTestFileNunit;

using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using global::EasyTestFile;

public static class EasyTestFile
{
    public static TestFile Load(
        EasyTestFileSettings? settings = null,
        [CallerFilePath] string sourceFile = "",
        [CallerMemberName] string method = "")
    {
        return TestFileFactory.Create(settings, sourceFile, method);
    }

    public static Task<string> LoadAsText(
        EasyTestFileSettings? settings = null,
        [CallerFilePath] string sourceFile = "",
        [CallerMemberName] string method = "")
    {
        TestFile dataLoader = Load(settings, sourceFile, method);
        return dataLoader.AsText();
    }

    public static Task<Stream> LoadAsStream(
        EasyTestFileSettings? settings = null,
        [CallerFilePath] string sourceFile = "",
        [CallerMemberName] string method = "")
    {
        TestFile dataLoader = Load(settings, sourceFile, method);
        return Task.FromResult(dataLoader.AsStream());
    }
}