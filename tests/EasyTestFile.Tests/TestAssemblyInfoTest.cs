namespace EasyTestFile.Tests;

using System.Threading.Tasks;
using FluentAssertions;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class TestAssemblyInfoTest
{
    [Fact]
    public async Task TestAssemblyInfo_ShouldReflectInformation()
    {
        // arrange

        //act
        var sut = new TestAssemblyInfo(typeof(TestAssemblyInfoTest).Assembly);

        // assert
        await VerifyXunit.Verifier.Verify(new
            {
                AssemblyName = sut.Assembly.GetName().Name,
                sut.ProjectDirectory,
                sut.SolutionDirectory,
            });
    }
}