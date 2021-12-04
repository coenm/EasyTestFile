namespace EasyTestFile.Json.Tests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EasyTestFile.Json.Tests.TestEntities;
using EasyTestFileXunit;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

[UsesEasyTestFile]
[SuppressMessage("ReSharper", "InvokeAsExtensionMethod", Justification = "Improves readability SUT.")]
public class NewtonsoftDeserializeTest
{
    private static readonly EasyTestFileSettings _easyTestFileSettings = new();
    private static readonly JsonSerializer _customJsonSerializer = new();
    private static readonly TestEntity _testEntity = new();

    static NewtonsoftDeserializeTest()
    {
        _easyTestFileSettings.UseExtension("json");

        _customJsonSerializer.TypeNameHandling = TypeNameHandling.All;
        _customJsonSerializer.Formatting = Formatting.Indented;

        _testEntity.DateOfBirth = new DateTime(2020, 03, 05, 04, 14, 12);
        _testEntity.Name = "CoenM";
        _testEntity.Subs = new List<SubTestEntity>()
            {
                new SubTestEntity { Id = new Guid("073633D2-EDD1-4A1D-93B7-FA4A8B1B1A03"), },
                new SubTestEntity { Id = new Guid("841E3836-B1B2-4E45-979E-E0B2AD8FAD38"), },
                new SubTestEntity { Id = new Guid("86E2FB0B-30A8-4688-AD24-F7DA9385C43C"), },
            };
    }

    [Fact]
    public async Task AsObjectUsingNewtonsoft_ShouldDeserializeFile_WithoutSpecificSettings()
    {
        // arrange
        TestFile testFile = EasyTestFile.Load(_easyTestFileSettings);

        // act
        TestEntity result = await NewtonsoftDeserialize.AsObjectUsingNewtonsoft<TestEntity>(testFile);

        // assert
        result.Should().BeEquivalentTo(_testEntity);
    }
    
    [Fact]
    public async Task AsObjectUsingNewtonsoft_ShouldDeserializeFile_WhenUsingSpecificSerializer()
    {
        // arrange
        TestFile testFile = EasyTestFile.Load(_easyTestFileSettings);
    
        // act
        TestEntity result = await NewtonsoftDeserialize.AsObjectUsingNewtonsoft<TestEntity>(testFile, _customJsonSerializer);
    
        // assert
        result.Should().BeEquivalentTo(_testEntity);
    }

    [Fact]
    public async Task AsObjectUsingNewtonsoft_ShouldDeserializeFile_WhenUsingSettingsContainingSpecificSerializer()
    {
        // arrange
        var easyTestFileSettings = new EasyTestFileSettings(_easyTestFileSettings);
        easyTestFileSettings.SetNewtonSoftJsonSerializerSettings(_customJsonSerializer);
        TestFile testFile = EasyTestFile.Load(easyTestFileSettings);

        // act
        TestEntity result = await NewtonsoftDeserialize.AsObjectUsingNewtonsoft<TestEntity>(testFile);

        // assert
        result.Should().BeEquivalentTo(_testEntity);
    }

    [Fact]
    public void AsObjectUsingNewtonsoft_ShouldThrow_WhenTestFileIsNull1()
    {
        // arrange
        
        // act
        Func<Task> act = () =>  NewtonsoftDeserialize.AsObjectUsingNewtonsoft<TestEntity>(null!);

        // assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public void AsObjectUsingNewtonsoft_ShouldThrow_WhenTestFileIsNull2()
    {
        // arrange

        // act
        Func<Task> act = () => NewtonsoftDeserialize.AsObjectUsingNewtonsoft<TestEntity>(null!, new JsonSerializer());

        // assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public void AsObjectUsingNewtonsoft_ShouldThrow_WhenSerializerIsNull()
    {
        // arrange
        TestFile testFile = EasyTestFile.Load(_easyTestFileSettings);

        // act
        Func<Task> act = () => NewtonsoftDeserialize.AsObjectUsingNewtonsoft<TestEntity>(testFile, null!);

        // assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
}