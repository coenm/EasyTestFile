# EasyTestFile

EasyTestFile is a library that simplifies the creation and usage of testfiles in unittests. 
Testfiles (like text, json, xml, binary, jpg, etc. etc.) are named based on the class and method name, are created if not exist, and are embedded as resource making sure the execution of the test is deterministic and do not rely on untracked files etc.

# EasyTestFile.Nunit

This package is required when your project uses NUnit for unittesting. No setup is required.

## Samples

<!-- snippet: NunitLoadAsText -->
<a id='snippet-nunitloadastext'></a>
```cs
[Test]
public async Task LoadAsText()
{
    // Executing this test for the first time will create an empty testfile and throw an exception.
    // Executing this test for the second time, this statement will read the testfile
    // and returns the content as a string.
    string text = await EasyTestFile.LoadAsText();

    // and do whatever you want
}
```
<sup><a href='/tests/EasyTestFile.Nunit.Tests/Samples/UnitTestClass.cs#L11-L22' title='Snippet source file'>snippet source</a> | <a href='#snippet-nunitloadastext' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: NunitLoadAsStream -->
<a id='snippet-nunitloadasstream'></a>
```cs
[Test]
public async Task LoadAsStream()
{
    // You can also load the testfile content as a stream.
    Stream stream = await EasyTestFile.LoadAsStream();

}
```
<sup><a href='/tests/EasyTestFile.Nunit.Tests/Samples/UnitTestClass.cs#L24-L32' title='Snippet source file'>snippet source</a> | <a href='#snippet-nunitloadasstream' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Or load the TestFile object first

<!-- snippet: NunitLoadAsTestFileBasic -->
<a id='snippet-nunitloadastestfilebasic'></a>
```cs
[Test]
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
<sup><a href='/tests/EasyTestFile.Nunit.Tests/Samples/UnitTestClass.cs#L58-L71' title='Snippet source file'>snippet source</a> | <a href='#snippet-nunitloadastestfilebasic' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

