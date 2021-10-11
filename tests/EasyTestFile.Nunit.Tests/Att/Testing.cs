namespace EasyTestFileNunit.Tests.Att
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using global::EasyTestFile;
    using global::EasyTestFile.Json;
    using NUnit.Framework;

    public class Testing
    {
        [Test]
        public async Task NewtonsoftLoad()
        {
            TestEntity entity = await EasyTestFile.Load().AsObjectUsingNewtonsoft<TestEntity>();

            _ = entity.Should().BeEquivalentTo(new TestEntity()
                {
                    Name = "Martin Luther King",
                    DateOfBirth = new DateTime(1929, 01, 15),
                });
        }

        [Test]
        public async Task Settings()
        {
            var settings = new EasyTestFileSettings();
            _ = settings.UseExtension("json");
            TestEntity entity = await EasyTestFile.Load(settings).AsObjectUsingNewtonsoft<TestEntity>();

            _ = entity.Should().BeEquivalentTo(new TestEntity()
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
            _ = await act.Should().ThrowAsync<TestFileNotFoundException>();
        }

        [Test]
        public async Task Test1()
        {
            var content = await EasyTestFile.LoadAsText();
            _ = content.Should().Be("test1");
        }

        [Test]
        public async Task Test2()
        {
            var content = await EasyTestFile.LoadAsText();
            _ = content.Should().Be("test2");
        }

        [Test]
        public async Task Test3()
        {
            var content = await EasyTestFile.LoadAsText(method: nameof(Test2));
            _ = content.Should().Be("test2");
        }
    }
}
