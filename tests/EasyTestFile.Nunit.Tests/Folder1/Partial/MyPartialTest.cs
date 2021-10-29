namespace EasyTestFileNunit.Tests.Folder1.Partial;

using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

public partial class MyPartialTest
{
    [Test]
    public async Task Test1()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test1");
    }

    [Test]
    public async Task Test2()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test2");
    }
}