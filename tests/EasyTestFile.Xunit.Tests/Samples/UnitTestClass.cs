namespace EasyTestFileXunit.Tests.Samples;

using System.IO;
using System.Threading.Tasks;
using global::EasyTestFile;
using global::EasyTestFile.Json;
using Xunit;

[UsesEasyTestFile]
public class UnitTestClass
{
    // begin-snippet: LoadAsText
    [Fact]
    public async Task LoadAsText()
    {
        // Executing this test for the first time will create an empty testfile and throw an exception.
        // Executing this test for the second time, this statement will read the testfile
        // and returns the content as a string.
        string text = await EasyTestFile.LoadAsText();

        // and do whatever you want
    }
    // end-snippet

    // begin-snippet: LoadAsStream
    [Fact]
    public async Task LoadAsStream()
    {
        // You can also load the testfile content as a stream.
        Stream stream = await EasyTestFile.LoadAsStream();

    }
    // end-snippet

    
    // begin-snippet: LoadJson
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
    // end-snippet


    // begin-snippet: LoadAsTestFileBasic
    [Fact]
    public async Task LoadAsTestFile()
    {
        // You can also load the test file as a TestFile object.
        TestFile testFile = EasyTestFile.Load();

        // then you can load the content as a stream
        Stream stream = await testFile.AsStream();

        // or like
        string text = await testFile.AsText();
    }
    // end-snippet

    // begin-snippet: LoadAsTestFile
    [Fact]
    public async Task LoadAsTestFileWithJson()
    {
        // You can also load the test file as a TestFile object.
        TestFile testFile = EasyTestFile.Load();

        // then you can load the content as a stream
        Stream stream = await testFile.AsStream();

        // or use extension methods like
        Person person = await testFile.AsObjectUsingNewtonsoft<Person>();

        // or like
        string text = await testFile.AsText();
    }
    // end-snippet

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used for markdown")]
    private async Task Configuration()
    {
        // begin-snippet: Configuration
        var settings = new EasyTestFileSettings();
        
        // specify assembly containing the testfiles (only applicable when embedded).
        settings.UseAssembly(typeof(Person).Assembly);

        // custom directory where testfiles are stored.
        settings.UseDirectory("myTestFiles");

        settings.UseFileName("filename");
        // or
        settings.UseMethodName("Configuration2");
        settings.SetTestFileNameSuffix("suffix");

        settings.UseExtension("jpg");
        settings.DisableAutoCreateMissingTestFile();

        // Load testfile as object with settings.
        TestFile testFile = EasyTestFile.Load(settings);

        // or directly as content with settings.
        var text = await EasyTestFile.LoadAsText(settings);
        // end-snippet
    }
}