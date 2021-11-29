namespace EasyTestFile.Json.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using VerifyXunit;
using Xunit;
using Sut = EasyTestFileSettingsExtension;

[UsesVerify]
[SuppressMessage("ReSharper", "InvokeAsExtensionMethod", Justification = "Improves readability SUT.")]
public class EasyTestFileSettingsExtensionTest
{
    [Fact]
    public void SetNewtonSoftJsonSerializerSettings1()
    {
        // arrange
        var settings1 = new EasyTestFileSettings();
        var jsonSerializer = new JsonSerializer();
        Sut.SetNewtonSoftJsonSerializerSettings(settings1, jsonSerializer);

        // act
        JsonSerializer result = Sut.GetNewtonSoftJsonSerializerSettings(settings1);

        // assert
        result.Should().BeSameAs(jsonSerializer);
    }
    
    [Fact]
    public void SetNewtonSoftJsonSerializerSettings_ShouldSaveSettingsInContext()
    {
        // arrange
        var settings = new EasyTestFileSettings();
        var jsonSerializer = new JsonSerializer();
        
        // act
        Sut.SetNewtonSoftJsonSerializerSettings(settings, jsonSerializer);
        
        // assert
        settings.Context.Should().ContainKey("Newtonsoft.Json.JsonSerializer").WhoseValue.Should().BeSameAs(jsonSerializer);
    }

    [Fact]
    public void SetNewtonSoftJsonSerializerSettings_ShouldOverrideSettingsInContext_WhenAlreadyStored()
    {
        // arrange
        var settings = new EasyTestFileSettings();
        var jsonSerializer1 = new JsonSerializer();
        var jsonSerializer2 = new JsonSerializer();
        Sut.SetNewtonSoftJsonSerializerSettings(settings, jsonSerializer1);

        // act
        Sut.SetNewtonSoftJsonSerializerSettings(settings, jsonSerializer2);

        // assert
        settings.Context.Should().ContainKey("Newtonsoft.Json.JsonSerializer").WhoseValue.Should().BeSameAs(jsonSerializer2);
    }

    [Fact]
    public void SetNewtonSoftJsonSerializerSettings_ShouldThrow_WhenSettingsArgumentIsNull()
    {
        // arrange

        // act
        Action act = () => Sut.SetNewtonSoftJsonSerializerSettings(null!, new JsonSerializer());
        
        // assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void SetNewtonSoftJsonSerializerSettings_ShouldThrow_WhenJsonSerializerArgumentIsNull()
    {
        // arrange

        // act
        Action act = () => Sut.SetNewtonSoftJsonSerializerSettings(new EasyTestFileSettings(), null!);
        
        // assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }
}