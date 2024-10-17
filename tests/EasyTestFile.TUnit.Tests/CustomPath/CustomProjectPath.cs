namespace EasyTestFileTUnit.Tests.CustomPath;

using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;

public class CustomProjectPath
{
    [Test]
    [Arguments(1, "CustomPathTest2 1", 1)]
    [Arguments(2, "CustomPathTest2 2", 1)]
    [Arguments(2, "CustomPathTest2 2", 2)]
    #pragma warning disable xUnit1026 // Theory methods should use all of their parameters. Justification: intentional
    public async Task CustomPathTest2(int input, string expectedContent, int _)
    {
        var settings = new EasyTestFileSettings();
        settings.SetTestFileNameSuffix(input);

        var content = await EasyTestFile.LoadAsText(settings);
        content.Should().Be(expectedContent);
    }
}