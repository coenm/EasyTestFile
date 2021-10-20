namespace EasyTestFile.Tests;

using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

public class EasyTestFileSettingsTest
{
    [Fact]
    public void Settings_ShouldHaveSameValues_WhenCreatedFromSettings()
    {
        // arrange
        var jsonSettings = new JsonSerializerSettings() { ContractResolver = new AllDataContractResolver(), };

        var settings1 = new EasyTestFileSettings();

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        settings1.Should().NotBeSameAs(settings2);

        var jsonSettings1 = JsonConvert.SerializeObject(settings1, Formatting.Indented, jsonSettings);
        var jsonSettings2 = JsonConvert.SerializeObject(settings2, Formatting.Indented, jsonSettings);
        jsonSettings1.Should().Be(jsonSettings2);
    }
}