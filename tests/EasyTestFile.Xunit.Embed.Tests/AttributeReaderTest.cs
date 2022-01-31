namespace EasyTestFileXunit.Embed.Tests;

using FluentAssertions;
using Xunit;
using global::EasyTestFile;
using global::EasyTestFile.Internals;

public class AttributeReaderTest
{
    [Fact]
    public void EasyTestFileModeShouldBeEmbed()
    {
        // arrange

        // act
        var result = AttributeReader.TryGetEasyTestFileMode(typeof(AttributeReaderTest).Assembly, out EasyTestFileMode? mode);

        // assert
        result.Should().BeTrue();
        mode.Should().Be(EasyTestFileMode.Embed);
    }
}