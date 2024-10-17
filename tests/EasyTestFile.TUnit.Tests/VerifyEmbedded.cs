namespace EasyTestFileTUnit.Tests;

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public class VerifyEmbedded
{
    [Test]
    public async Task VerifyEmbeddedFiles()
    {
        Assembly assembly = await GetAssemblyOfType(typeof(VerifyEmbedded));
        IOrderedEnumerable<string> resources = assembly.GetManifestResourceNames().OrderBy(name => name);
        await VerifyTUnit.Verifier.Verify(resources);
    }

    [Test]
    public async Task VerifyAssemblyMetadataAttributes()
    {
        Assembly assembly = await GetAssemblyOfType(typeof(VerifyEmbedded));
        IOrderedEnumerable<AssemblyMetadataAttribute> values = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().OrderBy(item => item.Key);
        await VerifyTUnit.Verifier.Verify(values);
    }

    private static async Task<Assembly> GetAssemblyOfType(Type t)
    {
        var currentAssembly = Assembly.GetAssembly(t);
        await Assert.That(currentAssembly).IsNotNull();
        return currentAssembly!;
    }
}