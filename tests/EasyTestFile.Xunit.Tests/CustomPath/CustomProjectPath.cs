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
    #pragma warning disable xUnit1026 // Theory methods should use all of their parameters. Justification: intentional
    public async Task CustomPathTest2(int input, string expectedContent, int _)
    {
        var settings = new EasyTestFileSettings();
        settings.SetTestFileNameSuffix(input);

        var content = await EasyTestFile.LoadAsText(settings);
        content.Should().Be(expectedContent);
    }
}