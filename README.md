# EasyTestFile

EasyTestFile is a library that simplifies the creation and using external testfiles in unittests.

## XUnit

<!-- snippet: XUnitAttributeUsage -->
<a id='snippet-xunitattributeusage'></a>
```cs
[UsesEasyTestFile]
public partial class UnitTestClass
{
    // The attribute is required when using XUnit.
}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/Samples.cs#L10-L16' title='Snippet source file'>snippet source</a> | <a href='#snippet-xunitattributeusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## NUnit

No special attributes or configuration is required to use EasyTestFile in combination with NUnit.

## MS Test
Todo.

## API

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
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/Samples.cs#L31-L42' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadastext' title='Start of snippet'>anchor</a></sup>
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
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/Samples.cs#L44-L52' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadasstream' title='Start of snippet'>anchor</a></sup>
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
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/Samples.cs#L58-L75' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadastestfile' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
