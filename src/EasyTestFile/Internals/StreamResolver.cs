namespace EasyTestFile.Internals;

using System.IO;
using System.Reflection;

internal static class StreamResolver
{
    internal static Stream? Resolve(string relativeFilename, string absoluteFilename, Assembly assembly)
    {
        return null
               ?? ResolveFromAssembly(assembly, relativeFilename)
               ?? ResolveFromSourceFilename(absoluteFilename)
               ?? ResolveFromOutputDirectory(assembly, relativeFilename);
    }

    private static Stream? ResolveFromAssembly(Assembly assembly, string relativeFilename)
    {
        var assemblyResourceFilename = "{EasyTestFile}/" + relativeFilename.Replace('\\', '/').TrimStart('/');
        return assembly.GetManifestResourceStream(assemblyResourceFilename);
    }

    private static Stream? ResolveFromSourceFilename(string physicalFilename)
    {
        var operatingSystemFullFilename = DirectorySanitizer.ToOperatingSystemPath(physicalFilename);

        if (!string.IsNullOrWhiteSpace(operatingSystemFullFilename) && File.Exists(operatingSystemFullFilename))
        {
            return File.OpenRead(operatingSystemFullFilename);
        }

        return null;
    }

    private static Stream? ResolveFromOutputDirectory(Assembly assembly, string relativeFilename)
    {
        // todo
        return null;
    }
}