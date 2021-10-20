namespace EasyTestFileNunit.Tests.CustomPath;

using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;
using NUnit.Framework;

public class CustomProjectPath
{
    [Test]
    public async Task CustomPathTest1()
    {
        var settings = new EasyTestFileSettings();
        settings.UseBaseDirectory(".customBaseFolder");

        var content = await EasyTestFile.LoadAsText(settings);
        _ = content.Should().Be("CustomPathTest1");
    }

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

    [Test]
    [TestCase(1, "CustomPathTest3 1", 1)]
    [TestCase(2, "CustomPathTest3 2", 1)]
    [TestCase(2, "CustomPathTest3 2", 2)]
    public async Task CustomPathTest3(int input, string expectedContent, int __)
    {
        var settings = new EasyTestFileSettings();
        settings.UseBaseDirectory(".customBaseFolder");
        settings.SetTestFileNameSuffix(input);

        var content = await EasyTestFile.LoadAsText(settings);
        _ = content.Should().Be(expectedContent);
    }
}