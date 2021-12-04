# EasyTestFile

EasyTestFile is a library that simplifies the creation and usage of testfiles in unittests. 
Testfiles (like text, json, xml, binary, jpg, etc. etc.) are named based on the class and method name, are created if not exist, and are embedded as resource making sure the execution of the test is deterministic and do not rely on untracked files etc.

# EasyTestFile.XUnit

This package is required when your project uses NUnit for unittesting. Make sure your test class is annotated with the attribute `[EasyTestFileXunit.UsesEasyTestFile]`.

## Attribute usage
<!-- snippet: XUnitAttributeUsage -->
<a id='snippet-xunitattributeusage'></a>
```cs
[UsesEasyTestFile]
public class TestClass1
{
    // The attribute is required when using XUnit.
}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/Samples.cs#L6-L12' title='Snippet source file'>snippet source</a> | <a href='#snippet-xunitattributeusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## Usage

Default options to load as text or load as stream:

<!-- snippet: LoadAsText -->
<a id='snippet-loadastext'></a>
```cs
[Fact]
public async Task LoadAsText()
{
    // Executing this test for the first time will create an empty testfile and throw an exception.
    // Executing this test for the second time, this statement will read the testfile
    // and returns the content as a string.
    string text = await EasyTestFile.LoadAsText();

    // and do whatever you want
}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/UnitTestClass.cs#L12-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadastext' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: LoadAsStream -->
<a id='snippet-loadasstream'></a>
```cs
[Fact]
public async Task LoadAsStream()
{
    // You can also load the testfile content as a stream.
    Stream stream = await EasyTestFile.LoadAsStream();

}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/UnitTestClass.cs#L25-L33' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadasstream' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Or load the TestFile object first

<!-- snippet: LoadAsTestFileBasic -->
<a id='snippet-loadastestfilebasic'></a>
```cs
[Fact]
public async Task LoadAsTestFile()
{
    // You can also load the test file as a TestFile object.
    TestFile testFile = EasyTestFile.Load();

    // then you can load the content as a stream
    Stream stream = testFile.AsStream();

    // or like
    string text = await testFile.AsText();
}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/UnitTestClass.cs#L59-L72' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadastestfilebasic' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
