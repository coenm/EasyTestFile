namespace EasyTestFileXunit.Tests.Folder1.Partial;

using System.Threading.Tasks;
using EasyTestFileXunit;
using FluentAssertions;
using Xunit;

// [UsesEasyTestFile] is already on the other partial class
public partial class MyPartialTest
{
    [Fact]
    public async Task Test3()
    {
        var content = await EasyTestFile.LoadAsText(method: nameof(Test2));
        _ = content.Should().Be("partial test3");
    }

    [Fact]
    public async Task Test4()
    {
        var content = await EasyTestFile.LoadAsText();
        _ = content.Should().Be("partial test4");
    }
}