namespace EasyTestFileNunit.Tests;

using System.Threading.Tasks;
using global::EasyTestFile;
using FluentAssertions;
using NUnit.Framework;

public class WithoutDotTestfile
{
    [Test]
    public async Task Test1()
    {
        var settings = new EasyTestFileSettings();
        settings.WithoutDotTestFileSuffix();

        var txt = await EasyTestFile.LoadAsText(settings);

        _ = txt.Should().Be("Without .testfile");
    }
}