namespace EasyTestFile.Tests;

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EasyTestFile.Internals;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using Sut = EasyTestFile.Internals.FileNameResolver;

[UsesVerify]
public class TestMethodInfoTest
{
    [Fact]
    public async Task Find_ShouldReturnCorrectAbsoluteAndRelativeFileNames()
    {
        // arrange

        // act
        TestMethodInfo sut = CreateTestMethodInfo(MethodBase.GetCurrentMethod()!);

        // assert
        await VerifyXunit.Verifier.Verify(sut);
    }

    private static TestMethodInfo CreateTestMethodInfo(MethodBase getCurrentMethod, [CallerMemberName] string member = "", [CallerFilePath] string file = "")
    {
        return new TestMethodInfo((MethodInfo)getCurrentMethod, file, member);
    }
}