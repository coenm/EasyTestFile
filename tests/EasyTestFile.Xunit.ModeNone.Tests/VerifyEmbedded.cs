namespace EasyTestFileXunit.ModeNone.Tests;

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[UsesVerify]
[UsesEasyTestFile]
public class VerifyEmbedded
{
    [Fact]
    public async Task VerifyEmbeddedFiles()
    {
        Assembly assembly = GetAssemblyOfType(typeof(VerifyEmbedded));
        IOrderedEnumerable<string> resources = assembly.GetManifestResourceNames().OrderBy(name => name);
        await VerifyXunit.Verifier.Verify(resources);
    }

    [Fact]
    public async Task VerifyAssemblyMetadataAttributes()
    {
        Assembly assembly = GetAssemblyOfType(typeof(VerifyEmbedded));
        IOrderedEnumerable<AssemblyMetadataAttribute> values = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().OrderBy(item => item.Key);
        await VerifyXunit.Verifier.Verify(values);
    }

    private static Assembly GetAssemblyOfType(Type t)
    {
        var currentAssembly = Assembly.GetAssembly(t);
        Assert.NotNull(currentAssembly);
        return currentAssembly!;
    }
}