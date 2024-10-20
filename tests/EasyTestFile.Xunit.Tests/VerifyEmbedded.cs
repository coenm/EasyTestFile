namespace EasyTestFileXunit.Tests;

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EasyTestFileXunit.Resources.CustomPath;
using VerifyXunit;
using Xunit;

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

    [Fact]
    public async Task VerifyEmbeddedFilesExternalLib()
    {
        Assembly assembly = GetAssemblyOfType(typeof(R));
        IOrderedEnumerable<string> resources = assembly.GetManifestResourceNames().OrderBy(name => name);
        await VerifyXunit.Verifier.Verify(resources);
    }

    [Fact]
    public async Task VerifyAssemblyMetadataAttributesExternalLib()
    {
        Assembly assembly = GetAssemblyOfType(typeof(R));
        IOrderedEnumerable<AssemblyMetadataAttribute> values = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().OrderBy(item => item.Key);
        await VerifyXunit.Verifier.Verify(values).UniqueForOSPlatform();
    }

    private static Assembly GetAssemblyOfType(Type t)
    {
        var currentAssembly = Assembly.GetAssembly(t);
        Assert.NotNull(currentAssembly);
        return currentAssembly!;
    }
}