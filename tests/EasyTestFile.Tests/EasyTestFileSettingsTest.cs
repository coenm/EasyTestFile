namespace EasyTestFile.Tests;

using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class EasyTestFileSettingsTest
{
    private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings() { ContractResolver = new AllDataContractResolver(), };

    [Fact]
    public async Task WhenCreatedFromSettings()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }

    [Fact]
    public async Task WithDisableAutoCreateMissingTestFile()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.DisableAutoCreateMissingTestFile();
            
        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }

    [Fact]
    public async Task WithSetTestFileNameSuffix1()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.SetTestFileNameSuffix(1);
            
        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }

    [Fact]
    public async Task WithSetTestFileNameSuffixString()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.SetTestFileNameSuffix("test123");
            
        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }
    
    [Fact]
    public void WithUseAssembly()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.UseAssembly(typeof(EasyTestFileSettingsTest).Assembly);

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        settings1.Assembly.Should().BeSameAs(typeof(EasyTestFileSettingsTest).Assembly);
        settings2.Assembly.Should().BeSameAs(typeof(EasyTestFileSettingsTest).Assembly);
    }

    [Fact]
    public async Task WithWithoutDotTestFileSuffix()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.WithoutDotTestFileSuffix();

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }

    [Fact]
    public async Task WithUseExtension()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.UseExtension("json");

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }

    [Fact]
    public async Task WithUseFileName()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        settings1.UseFileName("filename.txt");

        // act
        var settings2 = new EasyTestFileSettings(settings1);

        // assert
        var json = AssertSettingsUsingJson(settings1, settings2);
        await VerifyXunit.Verifier.VerifyJson(json);
    }

    private static string AssertSettingsUsingJson(EasyTestFileSettings settings1, EasyTestFileSettings settings2)
    {
        var jsonSettings1 = JsonConvert.SerializeObject(settings1, Formatting.Indented, _jsonSettings);
        var jsonSettings2 = JsonConvert.SerializeObject(settings2, Formatting.Indented, _jsonSettings);
        settings1.Should().NotBeSameAs(settings2);
        jsonSettings1.Should().Be(jsonSettings2);
        return jsonSettings1;
    }
}