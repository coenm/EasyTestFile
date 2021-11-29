namespace EasyTestFile.Json.Tests;

using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

public class EasyTestFileSettingsTest
{
    [Fact]
    public void Ctor_ShouldCopyJsonSerializer_WhenSetInBase()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        var jsonSerializer = new JsonSerializer();
        settings1.SetNewtonSoftJsonSerializerSettings(jsonSerializer);

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        settings1.Context.Should().BeEquivalentTo(settings2.Context);
    }
}