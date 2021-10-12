namespace EasyTestFile.Tests.Internals;

using FluentAssertions;
using Xunit;
using Sut = EasyTestFile.Internals.StringHelpers;

public class StringHelperTest
{
    [Theory]
    [InlineData("a","x","y","a")]
    [InlineData("abc","b","y","ayc")]
    [InlineData("abc","B","y","ayc")]
    [InlineData("abc","ab","y","yc")]
    [InlineData("abc","aB","y","yc")]
    [InlineData("abc","Ab","y","yc")]
    [InlineData("E:\\projects\\coenm\\EasyTestFile\\tests\\EasyTestFile.Tests\\Internals\\FileNameResolverTest_Abc.testfile.txt", "E:\\projects\\coenm\\EasyTestFile\\tests\\EasyTestFile.Tests\\", "", "Internals\\FileNameResolverTest_Abc.testfile.txt")]
    public void StringReplaceIgnoreCase_Scenarios(string input, string search, string replace, string expected)
    {
        // arrange

        // act
        var result = Sut.StringReplaceIgnoreCase(input, search, replace);

        // assert
        result.Should().Be(expected);
    }
}