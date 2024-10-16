namespace EasyTestFileTUnit.Tests.Att;

using System;
using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;
using global::EasyTestFile.Json;

public class Testing
{
    [Test]
    public async Task NewtonsoftLoad()
    {
        TestEntity entity = await EasyTestFile.Load().AsObjectUsingNewtonsoft<TestEntity>();

        entity.Should().BeEquivalentTo(new TestEntity()
            {
                Name = "Martin Luther King",
                DateOfBirth = new DateTime(1929, 01, 15),
            });
    }

    [Test]
    public async Task Settings()
    {
        var settings = new EasyTestFileSettings();
        settings.UseExtension("json");
        TestEntity entity = await EasyTestFile.Load(settings).AsObjectUsingNewtonsoft<TestEntity>();

        entity.Should().BeEquivalentTo(new TestEntity()
            {
                Name = "Martin Luther King",
                DateOfBirth = new DateTime(1929, 01, 15),
            });
    }

    [Test]
    public async Task ThrowsWhenNotExist()
    {
        var settings = new EasyTestFileSettings();
        settings.DisableAutoCreateMissingTestFile();
        Func<Task<string>> act = async () => await EasyTestFile.Load(settings, method: "does_not_exist").AsText();
        await act.Should().ThrowAsync<TestFileNotFoundException>();
    }

    [Test]
    public async Task Test1()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("test1");
    }

    [Test]
    public async Task Test2()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("test2");
    }

    [Test]
    public async Task Test3()
    {
        var content = await EasyTestFile.LoadAsText(method: nameof(Test2));
        content.Should().Be("test2");
    }
}