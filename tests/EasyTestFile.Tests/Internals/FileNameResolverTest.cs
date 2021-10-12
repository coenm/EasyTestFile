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
        TestMethodInfo testMethodInfo = CreateTestMethodInfo(MethodBase.GetCurrentMethod()!);

        // act
        var (relativeFilename, absoluteFilename) = Sut.Find(settings, testAssemblyInfo, testMethodInfo);

        // assert
        await VerifyXunit.Verifier.Verify(new
            {
                relativeFilename,
                absoluteFilename,
            });
    }

    private static TestMethodInfo CreateTestMethodInfo(MethodBase getCurrentMethod, [CallerMemberName] string member = "", [CallerFilePath] string file = "")
    {
        return new TestMethodInfo((MethodInfo)getCurrentMethod, file, member);
    }
}