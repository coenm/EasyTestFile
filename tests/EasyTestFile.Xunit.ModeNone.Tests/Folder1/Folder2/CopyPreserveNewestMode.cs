namespace EasyTestFileXunit.ModeNone.Tests.Folder1.Folder2;

using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;
using Xunit;

[UsesEasyTestFile]
public class CopyPreserveNewestMode
{
    [Fact]
    public async Task LoadFile()
    {
        // arrange
        var text = await EasyTestFile.LoadAsText(new EasyTestFileSettings().UseExtension("json"));

        // act
        
        // assert
        text.Should().Be("{ \"message\": \"this is json\" }");
    }
}