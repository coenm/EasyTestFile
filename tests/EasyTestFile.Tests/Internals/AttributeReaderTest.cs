namespace EasyTestFile.Tests.Internals;

using System.IO;
using FluentAssertions;
using global::EasyTestFile.Internals;
using VerifyXunit;
using Xunit;

public class AttributeReaderTest
{
    [Fact]
    public void GetProjectDirectory_ShouldNotBeNullOrEmpty()
    {
        // arrange

        // act
        var result = AttributeReader.GetProjectDirectory();

        // assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().EndWith($"{DirectorySanitizer.DIRECTORY_SEPARATOR_CHAR}");
    }

    [Fact]
    public void TryGetProjectDirectory_ShouldNotBeNullOrEmpty()
    {
        // arrange

        // act
        var result = AttributeReader.TryGetProjectDirectory(out var projectDirectory);

        // assert
        result.Should().BeTrue();
        projectDirectory.Should().NotBeNullOrWhiteSpace();
        projectDirectory.Should().EndWith($"{DirectorySanitizer.DIRECTORY_SEPARATOR_CHAR}");
    }

    [Fact]
    public void GetSolutionDirectory_ShouldNotBeNullOrEmpty()
    {
        // This test depends on how the project was compiled
        // dotnet build EasyTestFile.csproj => fails the test
        // dotnet build EasyTestFile.sln => test will succeed

        // arrange

        // act
        var result = AttributeReader.GetSolutionDirectory();

        // assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().EndWith($"{DirectorySanitizer.DIRECTORY_SEPARATOR_CHAR}");
    }

    [Fact]
    public void TryGetSolutionDirectory_ShouldNotBeNullOrEmpty()
    {
        // This test depends on how the project was compiled
        // dotnet build EasyTestFile.csproj => fails the test
        // dotnet build EasyTestFile.sln => test will succeed

        // arrange

        // act
        var result = AttributeReader.TryGetSolutionDirectory(out var solutionDirectory);

        // assert
        result.Should().BeTrue();
        solutionDirectory.Should().NotBeNullOrWhiteSpace();
        solutionDirectory.Should().EndWith($"{DirectorySanitizer.DIRECTORY_SEPARATOR_CHAR}");
    }
}