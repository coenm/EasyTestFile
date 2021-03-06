namespace EasyTestFileXunit.Tests.Folder1.Folder2;

using System;
using System.IO;
using System.Threading.Tasks;
using EasyTestFile;
using EasyTestFile.Json;
using EasyTestFileNunit;
using FluentAssertions;
using NUnit.Framework;

public class PropertyTest
{
    private static TestFile PropertyFile1 => EasyTestFileNunit.EasyTestFile.Load();

    // ReSharper disable once MemberCanBePrivate.Global
    public static TestFile PropertyFile2 => EasyTestFileNunit.EasyTestFile.Load(new EasyTestFileSettings().UseExtension("json"));

    [Test]
    public async Task UseProperty_ShouldLoadFileWithPropertyName()
    {
        var text = await PropertyFile1.AsText();
        text.Should().Be("content of PropertyFile1 testfiles");
    }

    [Test]
    public async Task UseProperty_ShouldRespectConfig()
    {
        var text = await PropertyFile2.AsText();
        text = text.Replace("\r\n", "\n");
        text.Should().Be("{\n    \"message\": \"this is json\"\n}");
    }

    [Test]
    public async Task UsePropertyTwice_ShouldReloadStream()
    {
        Stream s1 = await PropertyFile1.AsStream();
        Stream s2 = await PropertyFile1.AsStream();
        s1.Position = s1.Length - 1;
        s1.Dispose();

        s2.Position.Should().Be(0);
    }
}