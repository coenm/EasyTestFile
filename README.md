# EasyTestFile

EasyTestFile is a library that simplifies the creation and usage of testfiles in unittests. 
Testfiles (like text, json, xml, binary, jpg, etc. etc.) are named based on the class and method name, are created if not exist, and are embedded as resource making sure the execution of the test is deterministic and do not rely on untracked files etc.

At this moment, EasyTestFile can be used in combination with XUnit and NUnit.

# Initial setup

Using EasyTestFile in XUnit requires an additional attribute.

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

No special attributes or configuration is required to use EasyTestFile in combination with NUnit.

# API

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

<!-- snippet: LoadAsTestFile -->
<a id='snippet-loadastestfile'></a>
```cs
[Fact]
public async Task LoadAsTestFile()
{
    // You can also load the test file as a TestFile object.
    TestFile testFile = EasyTestFile.Load();

    // then you can load the content as a stream
    Stream stream = testFile.AsStream();

    // or use extension methods like
    Person person = await testFile.AsObjectUsingNewtonsoft<Person>();

    // or like

    string text = await testFile.AsText();
}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/UnitTestClass.cs#L39-L56' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadastestfile' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


These three test methods produce the following testfiles according to the name convention `{class name}.{method name}.testfile.{extension}`

![Solution Explorer TestFiles](/docs/images/SolutionExplorerTestFiles.png)

# Credits

## VerifyTest

Verify is a snapshot tool that simplifies the assertion of complex data models and documents. Some ideas and parts of the implementation in this project are based on the [VerifyTest](http://github.com/verifyTests/Verify/).

## Icon

[Photo](https://thenounproject.com/term/photo/2013925) designed by [OCHA Visual](https://thenounproject.com/ochavisual) from [The Noun Project](https://thenounproject.com).
