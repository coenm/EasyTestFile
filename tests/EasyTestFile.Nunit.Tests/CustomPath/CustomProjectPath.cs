namespace EasyTestFileNunit.Tests.CustomPath;

using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;
using NUnit.Framework;

public class CustomProjectPath
{
    [Test]
    [TestCase(1, "CustomPathTest2 1", 1)]
    [TestCase(2, "CustomPathTest2 2", 1)]
    [TestCase(2, "CustomPathTest2 2", 2)]
    public async Task CustomPathTest2(int input, string expectedContent, int __)
    {
        var settings = new EasyTestFileSettings();
        settings.SetTestFileNameSuffix(input);

        var content = await EasyTestFile.LoadAsText(settings);
        _ = content.Should().Be(expectedContent);
    }
}