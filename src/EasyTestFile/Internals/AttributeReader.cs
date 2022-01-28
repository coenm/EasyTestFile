namespace EasyTestFile.Internals;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

internal static class AttributeReader
{
    private const string PROJECT_DIRECTORY = "EasyTestFile.ProjectDirectory";
    private const string SOLUTION_DIRECTORY = "EasyTestFile.SolutionDirectory";
    private const string EASY_TEST_FILE_MODE = "EasyTestFile.EasyTestFileMode";

    /// <exception cref="AssemblyMetadataAttributeNotFoundException">Thrown when the `CallingAssembly` doesn't contain an <seealso cref="AssemblyMetadataAttribute"/> with the ProjectDirectory.</exception>
    public static string GetProjectDirectory()
    {
        return GetProjectDirectory(Assembly.GetCallingAssembly());
    }

    /// <exception cref="AssemblyMetadataAttributeNotFoundException">Thrown when the `CallingAssembly` doesn't contain an <seealso cref="AssemblyMetadataAttribute"/> with the ProjectDirectory.</exception>
    public static string GetProjectDirectory(Assembly assembly)
    {
        return GetEscapedPathValue(assembly, PROJECT_DIRECTORY).Replace('/', '\\');
    }

    public static bool TryGetProjectDirectory([NotNullWhen(true)] out string? projectDirectory)
    {
        return TryGetProjectDirectory(Assembly.GetCallingAssembly(), out projectDirectory);
    }

    public static bool TryGetProjectDirectory(Assembly assembly, [NotNullWhen(true)] out string? projectDirectory)
    {
        return TryGetEscapedPathValue(assembly, PROJECT_DIRECTORY, out projectDirectory);
    }

    /// <exception cref="AssemblyMetadataAttributeNotFoundException">Thrown when the `CallingAssembly` doesn't contain an <seealso cref="AssemblyMetadataAttribute"/> with the SolutionDirectory.</exception>
    public static string GetSolutionDirectory()
    {
        return GetSolutionDirectory(Assembly.GetCallingAssembly());
    }

    /// <exception cref="AssemblyMetadataAttributeNotFoundException">Thrown when the <paramref name="assembly"/> doesn't contain an <seealso cref="AssemblyMetadataAttribute"/> with the SolutionDirectory.</exception>
    public static string GetSolutionDirectory(Assembly assembly)
    {
        return GetEscapedPathValue(assembly, SOLUTION_DIRECTORY);
    }

    public static bool TryGetSolutionDirectory([NotNullWhen(true)] out string? solutionDirectory)
    {
        return TryGetSolutionDirectory(Assembly.GetCallingAssembly(), out solutionDirectory);
    }

    public static bool TryGetSolutionDirectory(Assembly assembly, [NotNullWhen(true)] out string? solutionDirectory)
    {
        return TryGetEscapedPathValue(assembly, SOLUTION_DIRECTORY, out solutionDirectory);
    }

    public static bool TryGetEasyTestFileMode(Assembly assembly, [NotNullWhen(true)] out EasyTestFileMode? mode)
    {
        if (!TryGetValue(assembly, EASY_TEST_FILE_MODE, out var easyTestFileModeString))
        {
            mode = null;
            return false;
        }

        if (easyTestFileModeString.Equals("Embed", StringComparison.InvariantCulture))
        {
            mode = EasyTestFileMode.Embed;
            return true;
        }

        if (easyTestFileModeString.Equals("CopyAlways", StringComparison.InvariantCulture))
        {
            mode = EasyTestFileMode.CopyAlways;
            return true;
        }

        if (easyTestFileModeString.Equals("CopyPreserveNewest", StringComparison.InvariantCulture))
        {
            mode = EasyTestFileMode.CopyPreserveNewest;
            return true;
        }

        if (easyTestFileModeString.Equals("None", StringComparison.InvariantCulture))
        {
            mode = EasyTestFileMode.None;
            return true;
        }

        mode = null;
        return false;
    }

    private static bool TryGetEscapedPathValue(Assembly assembly, string key, [NotNullWhen(true)] out string? value)
    {
        if (TryGetValue(assembly, key, out value))
        {
            value = value.Replace('\\', DirectorySanitizer.DIRECTORY_SEPARATOR_CHAR);
            return true;
        }

        value = null;
        return false;
    }

    /// <exception cref="AssemblyMetadataAttributeNotFoundException">Thrown when an expected AssemblyMetadataAttribute was not found.</exception>
    private static string GetEscapedPathValue(Assembly assembly, string key)
    {
        if (TryGetEscapedPathValue(assembly, key, out var value))
        {
            return value;
        }

        throw new AssemblyMetadataAttributeNotFoundException(assembly.GetName().FullName, key);
    }

    private static bool TryGetValue(Assembly assembly, string key, [NotNullWhen(true)] out string? value)
    {
        value = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
                        .SingleOrDefault(x => x.Key == key)
                        ?.Value;
        return value != null;
    }

    /// <exception cref="AssemblyMetadataAttributeNotFoundException">Thrown when an expected AssemblyMetadataAttribute was not found.</exception>
    private static string GetValue(Assembly assembly, string key)
    {
        if (TryGetValue(assembly, key, out var value))
        {
            return value;
        }

        throw new AssemblyMetadataAttributeNotFoundException(assembly.GetName().FullName, key);
    }
}