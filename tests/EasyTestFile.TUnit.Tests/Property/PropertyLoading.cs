namespace EasyTestFileTUnit.Tests.Property;

using System;
using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;
using global::EasyTestFile.Json;

public class PropertyLoading
{
    // EasyTestFile loads the data before the test started.
    private string _text1;
    private string _text2;

    private static TestFile MyData => EasyTestFileTUnit.EasyTestFile.Load();

    private static TestFile MyData2 { get; } = EasyTestFileTUnit.EasyTestFile.Load();

    private static string MyData3 => EasyTestFileTUnit.EasyTestFile.LoadAsText().GetAwaiter().GetResult();

    public PropertyLoading()
    {
        InitializeAsync().GetAwaiter().GetResult();
    }
    
    private async Task InitializeAsync()
    {
        // this is executed before the test
        _text1 = await MyData.AsText();
        _text2 = await MyData2.AsText();
    }

    [Test]
    public void Test1()
    {
        _text1.Should().Be("From textfile");
    }

    [Test]
    public void Test2()
    {
        _text2.Should().Be("From textfile2");
    }

    [Test]
    public void Test3()
    {
        MyData3.Should().Be("From textfile3");
    }
}