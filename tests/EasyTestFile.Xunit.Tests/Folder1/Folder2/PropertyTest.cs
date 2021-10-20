namespace EasyTestFileXunit.Tests.Folder1.Folder2;

using System;
using System.IO;
using System.Threading.Tasks;
using global::EasyTestFile;
using global::EasyTestFile.Json;
using EasyTestFileXunit.Tests.Att;
using FluentAssertions;
using Xunit;

[UsesEasyTestFile]
public class PropertyTest
{
    private TestFile PropertyFile1 => EasyTestFile.Load();

    // ReSharper disable once MemberCanBePrivate.Global
    public TestFile PropertyFile2 => EasyTestFile.Load(new EasyTestFileSettings().UseExtension("json"));

    [Fact]
    public async Task UseProperty_ShouldLoadFileWithPropertyName()
    {
        var text = await PropertyFile1.AsText();
        _ = text.Should().Be("content of PropertyFile1 testfiles");
    }

    [Fact]
    public async Task UseProperty_ShouldRespectConfig()
    {
        var text = await PropertyFile2.AsText();
        _ = text.Should().Be("{\r\n    \"message\": \"this is json\"\r\n}");
    }

    [Fact]
    public void UsePropertyTwice_ShouldReloadStream()
    {
        Stream s1 = PropertyFile1.AsStream();
        Stream s2 = PropertyFile1.AsStream();
        s1.Position = s1.Length - 1;
        s1.Dispose();

        _ = s2.Position.Should().Be(0);
    }
}