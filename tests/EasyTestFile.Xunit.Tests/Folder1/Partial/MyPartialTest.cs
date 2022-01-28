namespace EasyTestFileXunit.Tests.Folder1.Partial;

using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using global::EasyTestFile;
using global::EasyTestFile.Json;
using EasyTestFileXunit;

[UsesEasyTestFile]
public partial class MyPartialTest
{
    [Fact]
    public async Task Test1()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test1");
    }

    [Fact]
    public async Task Test2()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test2");
    }

    [Fact]
    public async Task UseDirectory()
    {
        var settings = new EasyTestFileSettings();
        settings.UseDirectory("MyDirectory");

        var content = await EasyTestFile.LoadAsText(settings);

        content.Should().Be("CustomDirectory content");
    }

    [Fact]
    public async Task UseMethodName()
    {
        var settings = new EasyTestFileSettings();
        settings.UseDirectory("MyDirectory");
        settings.UseMethodName("MyMethodName");

        var content = await EasyTestFile.LoadAsText(settings);

        content.Should().Be("CustomDirectory with my method name");
    }

    [Fact]
    public async Task UseFileName()
    {
        var settings = new EasyTestFileSettings();
        settings.UseDirectory("MyDirectory");
        settings.UseFileName("MyFilename");

        var content = await EasyTestFile.LoadAsText(settings);

        content.Should().Be("CustomDirectory with my filename");
    }
}