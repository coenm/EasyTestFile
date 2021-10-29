namespace EasyTestFileXunit.Tests.Folder1.Partial;

using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using global::EasyTestFile;
using global::EasyTestFile.Json;
using EasyTestFileXunit;

[UsesEasyTestFile]
public partial class MyPartialTest
{
    [Fact]
    public async Task Test1()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test1");
    }

    [Fact]
    public async Task Test2()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test2");
    }
}