namespace EasyTestFile;

using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Contains extensions of <see cref="TestFile"/>.
/// </summary>
public static class TestFileAsText
{
    /// <summary>
    /// Returns content of <paramref name="testFile"/> as string.
    /// </summary>
    /// <param name="testFile">TestFile instance.</param>
    /// <returns>The text content of the test file.</returns>
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