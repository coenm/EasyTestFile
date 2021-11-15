# EasyTestFile

EasyTestFile is a library that simplifies the creation and usage of testfiles in unittests. 
Testfiles (like text, json, xml, binary, jpg, etc. etc.) are named based on the class and method name, are created if not exist, and are embedded as resource making sure the execution of the test is deterministic and do not rely on untracked files etc.

# EasyTestFile.Json

This package contains extension method(s) to deserialize TestFiles using json.

<!-- snippet: LoadJson -->
<a id='snippet-loadjson'></a>
```cs
[Fact] // or [Test]
public async Task JsonTestFile()
{
    // load testfile
    var settings = new EasyTestFileSettings();
    settings.UseExtension("json");
    TestFile testFile = EasyTestFile.Load(settings);

    // deserialize testfile using Newtonsoft Json.
    Person person = await testFile.AsObjectUsingNewtonsoft<Person>();

    // do something with person object
    // i.e. sut.Process(person);
}

public class Person
{
    public string Name { get; set; }
}
```
<sup><a href='/tests/EasyTestFile.Xunit.Tests/Samples/UnitTestClass.cs#L36-L56' title='Snippet source file'>snippet source</a> | <a href='#snippet-loadjson' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
