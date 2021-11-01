namespace EasyTestFile.Tests.Internals;

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using Sut = EasyTestFile.Internals.FileNameResolver;

[UsesVerify]
public class FileNameResolverTest
{
    [Fact]
    public async Task Find_ShouldReturnCorrectAbsoluteAndRelativeFileNames()
    {
        // arrange
        var settings = new EasyTestFileSettings();
        var testAssemblyInfo = new TestAssemblyInfo(typeof(FileNameResolverTest).Assembly);
        TestMethodInfo testMethodInfo = TestMethodInfoFactory.CreateTestMethodInfo(MethodBase.GetCurrentMethod()!);

        // act
        (string relativeFilename, string absoluteFilename) = Sut.Find(settings, testAssemblyInfo, testMethodInfo);

        // assert
        await VerifyXunit.Verifier.Verify(new
            {
                relativeFilename,
                absoluteFilename,
            });
    }
}