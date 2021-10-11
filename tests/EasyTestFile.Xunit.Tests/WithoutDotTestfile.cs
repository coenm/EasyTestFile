namespace EasyTestFileXunit.Tests
{
    using System.Threading.Tasks;
    using global::EasyTestFile;
    using EasyTestFileXunit.Resources.CustomPath;
    using FluentAssertions;
    using Xunit;

    [UsesEasyTestFile]
    public class WithoutDotTestfile
    {
        [Fact]
        public async Task Test1()
        {
            var settings = new EasyTestFileSettings();
            settings.WithoutDotTestFileSuffix();

            var txt = await EasyTestFile.LoadAsText(settings);

            _ = txt.Should().Be("Without .testfile");
        }
    }
}
