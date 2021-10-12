namespace EasyTestFile;

using System.IO;
using System.Threading.Tasks;

public static class TestFileExtensions
{
    public static Task<string> AsText(this TestFile testFile)
    {
        return AsText(testFile.AsStream());
    }

    internal static async Task<string> AsText(Stream stream)
    {
        using var sr = new StreamReader(stream);
        return await sr.ReadToEndAsync().ConfigureAwait(false);
    }
}