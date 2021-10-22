namespace EasyTestFileXunit.Tests.Sub;

using System.Threading.Tasks;
using global::EasyTestFile;
using FluentAssertions;
using Xunit;

[UsesEasyTestFile]
public class EasyTestFilesPath
{
    [Fact]
    public async Task Test1()
    {
        var settings = new EasyTestFileSettings();
        settings.UseEasyTestFileBaseDirectory();
        settings.UseFileName("test.txt");

        var txt = await EasyTestFile.LoadAsText(settings);

        _ = txt.Should().Be("settings.UseFileName(\"test.txt\");");
    }

/*
    [Fact]
    public async Task Test2()
    {
        var settings = new EasyTestFileSettings();
        settings.UseEasyTestFileBaseDirectory();

        var txt = await EasyTestFile.LoadAsText("test.txt", settings);

        _ = txt.Should().Be("settings.UseFileName(\"test.txt\");");
    }
 */       
    [Fact]
    public async Task Test3()
    {
        var settings = new EasyTestFileSettings();
        settings.UseFileName("test_ddd.txt");

        var txt = await EasyTestFile.LoadAsText(settings);

        _ = txt.Should().Be("settings.UseFileName(\"test_ddd.txt\");");
    }

    [Fact] 
    public async Task Test4()
    {
        var txt = await EasyTestFile.LoadAsText("test_ddd.txt");

        _ = txt.Should().Be("settings.UseFileName(\"test_ddd.txt\");");
    }        

    [Fact]
    public async Task Test5()
    {
        var settings = new EasyTestFileSettings();
        settings.UseFileName("Subdir\\test_123.txt");

        var txt = await EasyTestFile.LoadAsText(settings);

        _ = txt.Should().Be("subdir Subdir");
    }

    [Fact] 
    public async Task Test6()
    {
        var txt = await EasyTestFile.LoadAsText("Subdir\\test_123.txt");

        _ = txt.Should().Be("subdir Subdir");
    }

    [Fact]
    public async Task Test7()
    {
        var settings = new EasyTestFileSettings();
        settings.UseFileName("Subdir/test_123.txt");

        var txt = await EasyTestFile.LoadAsText(settings);

        _ = txt.Should().Be("subdir Subdir");
    }

    [Fact]
    public async Task Test8()
    {
        var txt = await EasyTestFile.LoadAsText("Subdir/test_123.txt");

        _ = txt.Should().Be("subdir Subdir");
    }
}