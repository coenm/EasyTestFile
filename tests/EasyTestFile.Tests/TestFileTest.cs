namespace EasyTestFile.Tests;

using System;
using System.Reflection;
using System.Threading.Tasks;
using EasyTestFile.Internals;
using FluentAssertions;
using VerifyXunit;
using Xunit;

public class TestFileTest
{
    [Fact]
    public void Ctor()
    {
        // arrange
        var settings = new EasyTestFileSettings();
        var testAssemblyInfo = new TestAssemblyInfo(typeof(TestFileTest).Assembly);
        TestMethodInfo testMethodInfo = TestMethodInfoFactory.CreateTestMethodInfo(MethodBase.GetCurrentMethod()!);

        // act
        Action act = () => _ = new TestFile(settings, testAssemblyInfo, testMethodInfo);

        // assert
        act.Should().NotThrow();
    }
}