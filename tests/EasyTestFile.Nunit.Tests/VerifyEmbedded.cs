namespace EasyTestFileNunit.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class VerifyEmbedded
    {
        [Test]
        public async Task VerifyEmbeddedFiles()
        {
            Assembly assembly = GetAssemblyOfType(typeof(VerifyEmbedded));
            IOrderedEnumerable<string> resources = assembly.GetManifestResourceNames().OrderBy(name => name);
            await VerifyNUnit.Verifier.Verify(resources);
        }

        [Test]
        public async Task VerifyAssemblyMetadataAttributes()
        {
            Assembly assembly = GetAssemblyOfType(typeof(VerifyEmbedded));
            IOrderedEnumerable<AssemblyMetadataAttribute> values = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().OrderBy(item => item.Key);
            await VerifyNUnit.Verifier.Verify(values);
        }

        private Assembly GetAssemblyOfType(Type t)
        {
            var currentAssembly = Assembly.GetAssembly(t);
            Assert.NotNull(currentAssembly);
            return currentAssembly!;
        }
    }
}
