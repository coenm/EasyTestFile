namespace EasyTestFile.Internals;

using System.IO;

internal static class FileNameResolver
{
    internal static string GetFileNamePrefix(EasyTestFileSettings settings, TestAssemblyInfo testAssemblyInfo, TestMethodInfo testMethodInfo)
    {
        _ = testAssemblyInfo;

        if (settings.FileName is not null)
        {
            return settings.FileName;
        }

        // var typeName = settings.typeName ?? pathInfo.TypeName ?? GetTypeName(type)
        var typeName = testMethodInfo.FileName;
        var methodName = settings.MethodName ?? testMethodInfo.Method;
        
        var suffix = string.Empty;
        if (!string.IsNullOrWhiteSpace(settings.TestFileNamingSuffix))
        {
            suffix = "." + settings.TestFileNamingSuffix;
        }
        
        return $"{typeName}.{methodName}{suffix}";
    }

    internal static (string Relative, string Absolute) GetDirectories(EasyTestFileSettings settings, TestAssemblyInfo testAssemblyInfo, TestMethodInfo testMethodInfo)
    {
        _ = testAssemblyInfo;
        var absoluteDir = testMethodInfo.SanitizedDirectory;
        if (settings.Directory is not null)
        {
            absoluteDir = DirectorySanitizer.Sanitize(Path.Combine(DirectorySanitizer.ToOperatingSystemPath(absoluteDir), settings.Directory));
        }

        absoluteDir = absoluteDir.TrimEnd('\\', '/');
        absoluteDir += DirectorySanitizer.DIRECTORY_SEPARATOR_CHAR;

        var relativeFilename = StringHelpers.StringReplaceIgnoreCase(absoluteDir, DirectorySanitizer.Sanitize(testAssemblyInfo.ProjectDirectory), string.Empty);

        return (relativeFilename, absoluteDir);
    }
}