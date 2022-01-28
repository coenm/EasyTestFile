namespace EasyTestFileXunit.ModeNone.Tests;

using FluentAssertions;
using global::EasyTestFile;
using global::EasyTestFile.Internals;
using Xunit;

public class AttributeReaderTest
{
    [Fact]
    public void EasyTestFileModeShouldBeNone()
    {
        // arrange

        // act
        var result = AttributeReader.TryGetEasyTestFileMode(typeof(AttributeReaderTest).Assembly, out EasyTestFileMode? mode);

        // assert
        result.Should().BeTrue();
        mode.Should().Be(EasyTestFileMode.None);
    }
}