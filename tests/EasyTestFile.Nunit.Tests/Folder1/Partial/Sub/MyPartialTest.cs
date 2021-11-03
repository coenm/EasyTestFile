namespace EasyTestFileNunit.Tests.Folder1.Partial;

using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

public partial class MyPartialTest
{
    [Test]
    public async Task Test3()
    {
        var content = await EasyTestFile.LoadAsText(method: nameof(Test2));
        content.Should().Be("partial test3");
    }

    [Test]
    public async Task Test4()
    {
        var content = await EasyTestFile.LoadAsText();
        content.Should().Be("partial test4");
    }
}