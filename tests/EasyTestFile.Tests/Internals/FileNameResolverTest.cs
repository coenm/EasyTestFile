namespace EasyTestFile.Tests.Internals;

using System.Reflection;
using System.Threading.Tasks;
using EasyTestFile.Internals;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using Sut = EasyTestFile.Internals.FileNameResolver;

[UsesVerify]
public class FileNameResolverTest
{
    [Fact]
    public void GetFileNamePrefix_ShouldReturnCorrectString()
    {
        // arrange
        var settings = new EasyTestFileSettings();
        var testAssemblyInfo = new TestAssemblyInfo(typeof(FileNameResolverTest).Assembly);
        TestMethodInfo testMethodInfo = TestMethodInfoFactory.CreateTestMethodInfo(MethodBase.GetCurrentMethod()!);

        // act
        var result = Sut.GetFileNamePrefix(settings, testAssemblyInfo, testMethodInfo);

        // assert
        result.Should().Be("FileNameResolverTest.GetFileNamePrefix_ShouldReturnCorrectString");
    }

    [Fact]
    public async Task GetDirectories_ShouldReturnCorrectAbsoluteAndRelativeFileNames()
    {
        // arrange
        var settings = new EasyTestFileSettings();
        var testAssemblyInfo = new TestAssemblyInfo(typeof(FileNameResolverTest).Assembly);
        TestMethodInfo testMethodInfo = TestMethodInfoFactory.CreateTestMethodInfo(MethodBase.GetCurrentMethod()!);

        // act
        var (relative, absolute) = Sut.GetDirectories(settings, testAssemblyInfo, testMethodInfo);

        // assert
        await VerifyXunit.Verifier.Verify(new
            {
                relative,
                absolute,
            });
    }
}