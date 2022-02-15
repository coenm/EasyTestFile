namespace EasyTestFileXunit.Tests.Property;

using System;
using System.Threading.Tasks;
using FluentAssertions;
using global::EasyTestFile;
using global::EasyTestFile.Json;
using Xunit;

[UsesEasyTestFile]
public class PropertyLoading : IAsyncLifetime
{
    // EasyTestFile loads the data before the test (fact, theory) started.
    // This uses a different approach to detect the current assembly.
    // Detection when the test is started is done using the UseEasyTestFile attribute,
    // detection before the test is started is done using Assembly.GetCallingAssembly().

    private string _text1;
    private string _text2;

    private static TestFile MyData => EasyTestFileXunit.EasyTestFile.Load();

    private static TestFile MyData2 { get; } = EasyTestFileXunit.EasyTestFile.Load();

    private static string MyData3 => EasyTestFileXunit.EasyTestFile.LoadAsText().GetAwaiter().GetResult();

    public async Task InitializeAsync()
    {
        // this is executed before the test
        _text1 = await MyData.AsText();
        _text2 = await MyData2.AsText();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public void Test1()
    {
        _text1.Should().Be("From textfile");
    }

    [Fact]
    public void Test2()
    {
        _text2.Should().Be("From textfile2");
    }

    [Fact]
    public void Test3()
    {
        MyData3.Should().Be("From textfile3");
    }
}