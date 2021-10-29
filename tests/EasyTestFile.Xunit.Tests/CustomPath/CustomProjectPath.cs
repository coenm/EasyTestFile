namespace EasyTestFileXunit.Tests.CustomPath;

using System;
using System.Threading.Tasks;
using global::EasyTestFile;
using FluentAssertions;
using Xunit;

[UsesEasyTestFile]
public class CustomProjectPath
{
    [Theory]
    [InlineData(1, "CustomPathTest2 1", 1)]
    [InlineData(2, "CustomPathTest2 2", 1)]
    [InlineData(2, "CustomPathTest2 2", 2)]
    public async Task CustomPathTest2(int input, string expectedContent, int __)
    {
        var settings = new EasyTestFileSettings();
        settings.SetTestFileNameSuffix(input);

        var content = await EasyTestFile.LoadAsText(settings);
        _ = content.Should().Be(expectedContent);
    }
}