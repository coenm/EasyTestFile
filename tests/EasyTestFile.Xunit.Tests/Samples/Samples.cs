namespace EasyTestFileXunit.Tests.Samples1
{
    using System.Threading.Tasks;
    using Xunit;

// begin-snippet: XUnitAttributeUsage
    [UsesEasyTestFile]
    public partial class UnitTestClass
    {
        // The attribute is required when using XUnit.
    }
    // end-snippet
}

namespace EasyTestFileXunit.Tests.Samples2
{
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

        public class Person
        {
        }

        // begin-snippet: LoadAsTestFile
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
        // end-snippet
    }
}