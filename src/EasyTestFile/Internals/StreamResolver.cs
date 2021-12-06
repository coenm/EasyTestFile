namespace EasyTestFile.Internals;

using System.IO;
using System.Reflection;
using EasyTestFile.DerivedPaths;

internal static class StreamResolver
{
    internal static Stream? Resolve(string relativeFilename, string absoluteFilename, Assembly assembly)
    {
        if (AttributeReader.TryGetEasyTestFileMode(assembly, out EasyTestFileMode? mode))
        {
            switch (mode)
            {
                case EasyTestFileMode.Embed:
                    return ResolveFromAssembly(assembly, relativeFilename);

                case EasyTestFileMode.CopyAlways:
                case EasyTestFileMode.CopyPreserveNewest:
                    return ResolveFromOutputFilename(relativeFilename);

                case EasyTestFileMode.None:
                    return ResolveFromSourceFilename(absoluteFilename);

                default:
                    throw new InternalErrorRaisePullRequestException($"Expected test mode to be handled in {nameof(StreamResolver)}.");
            }
        }

        return ResolveFromAssembly(assembly, relativeFilename)
               ?? ResolveFromOutputFilename(relativeFilename)
               ?? ResolveFromSourceFilename(absoluteFilename);
    }

    private static Stream? ResolveFromAssembly(Assembly assembly, string relativeFilename)
    {
        var assemblyResourceFilename = "{EasyTestFile}/" + relativeFilename.Replace('\\', '/').TrimStart('/');
        return assembly.GetManifestResourceStream(assemblyResourceFilename);
    }

    private static Stream? ResolveFromOutputFilename(string relativeFilename)
    {
        var outputFilename = DirectorySanitizer.ToOperatingSystemPath(relativeFilename);

        if (!string.IsNullOrWhiteSpace(outputFilename) && File.Exists(outputFilename))
        {
            return File.OpenRead(outputFilename);
        }

        return null;
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
}