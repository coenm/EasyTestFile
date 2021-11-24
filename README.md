# EasyTestFile

[![Nuget Status](https://img.shields.io/nuget/v/EasyTestFile.svg?label=EasyTestFile&style=flat-square)](https://www.nuget.org/packages/EasyTestFile/)
[![Nuget Status](https://img.shields.io/nuget/v/EasyTestFile.XUnit.svg?label=EasyTestFile.XUnit&style=flat-square)](https://www.nuget.org/packages/EasyTestFile.XUnit/)
[![Nuget Status](https://img.shields.io/nuget/v/EasyTestFile.NUnit.svg?label=EasyTestFile.NUnit&style=flat-square)](https://www.nuget.org/packages/EasyTestFile.NUnit/)
[![Nuget Status](https://img.shields.io/nuget/v/EasyTestFile.NewtonsoftJson.svg?label=EasyTestFile.NewtonsoftJson&style=flat-square)](https://www.nuget.org/packages/EasyTestFile.NewtonsoftJson/)


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
public async Task LoadAsTestFileWithJson()
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
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/UnitTestClass.cs#L75-L91' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadastestfile' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


These three test methods produce the following testfiles according to the name convention `{class name}.{method name}.testfile.{extension}`

![Solution Explorer TestFiles](/docs/images/SolutionExplorerTestFiles.png)

# Compile time Configuration

There is an optional option to control how tsetfiles are included in your artifacts. This can be controlled using the property `EasyTestFileMode`.
The options are:
- `None` TestFiles are not copied or embedded on compilation. EasyTestFile will load the files from the original source. This will speedup the compilation process but might be less reliable as files can be altered or deleted after compilation and before executing tests. Creating artifacts on buildservers in order to run the test in other environments might also be problematic as the testfiles are not included as artifact.
- `Embed` The testfiles are embedded as resource in the `dll` file. This will produce larger binaries, takes a little bit more time to compile but   makes the test deterministic as testfiles cannot be altered or deleted after compilation and before testing.
- `CopyAlways` This will always copy the testfile to the artifact/build directory.
- `CopyPreserveNewest` This will copy the testfile to the build directory when the file is newer.

When no (valid) value is provided, the `Embed` mode will be used.

Configuration is done like:

<!-- snippet: CompiletimeConfigurationEasyTestFileMode -->
<a id='snippet-compiletimeconfigurationeasytestfilemode'></a>
```csproj
<PropertyGroup>
	<EasyTestFileMode>CopyAlways</EasyTestFileMode>
</PropertyGroup>
```
<sup><a href='/tests/EasyTestFile.Xunit.CopyAlways.Tests/EasyTestFile.Xunit.CopyAlways.Tests.csproj#L28-L32' title='Snippet source file'>snippet source</a> | <a href='#snippet-compiletimeconfigurationeasytestfilemode' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

# Credits

## VerifyTest

Verify is a snapshot tool that simplifies the assertion of complex data models and documents. Some ideas and parts of the implementation in this project are based on the [VerifyTest](http://github.com/verifyTests/Verify/).

## Icon

[Photo](https://thenounproject.com/term/photo/2013925) designed by [OCHA Visual](https://thenounproject.com/ochavisual) from [The Noun Project](https://thenounproject.com).
