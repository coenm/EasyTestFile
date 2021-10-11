namespace EasyTestFile.DerivedPaths
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    internal static class AttributeReader
    {
        private const string PROJECT_DIRECTORY = "EasyTestFile.ProjectDirectory";
        private const string SOLUTION_DIRECTORY = "EasyTestFile.SolutionDirectory";

        public static string GetProjectDirectory()
        {
            return GetProjectDirectory(Assembly.GetCallingAssembly());
        }

        public static string GetProjectDirectory(Assembly assembly)
        {
            return GetValue(assembly, PROJECT_DIRECTORY);
        }

        public static bool TryGetProjectDirectory([NotNullWhen(true)] out string? projectDirectory)
        {
            return TryGetProjectDirectory(Assembly.GetCallingAssembly(), out projectDirectory);
        }

        public static bool TryGetProjectDirectory(Assembly assembly, [NotNullWhen(true)] out string? projectDirectory)
        {
            return TryGetValue(assembly, PROJECT_DIRECTORY, out projectDirectory);
        }

        public static string GetSolutionDirectory()
        {
            return GetSolutionDirectory(Assembly.GetCallingAssembly());
        }

        public static string GetSolutionDirectory(Assembly assembly)
        {
            return GetValue(assembly, SOLUTION_DIRECTORY);
        }

        public static bool TryGetSolutionDirectory([NotNullWhen(true)] out string? solutionDirectory)
        {
            return TryGetSolutionDirectory(Assembly.GetCallingAssembly(), out solutionDirectory);
        }

        public static bool TryGetSolutionDirectory(Assembly assembly, [NotNullWhen(true)] out string? solutionDirectory)
        {
            return TryGetValue(assembly, SOLUTION_DIRECTORY, out solutionDirectory);
        }

        private static bool TryGetValue(Assembly assembly, string key, [NotNullWhen(true)] out string? value)
        {
            value = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
                .SingleOrDefault(x => x.Key == key)
                ?.Value;
            return value != null;
        }

        private static string GetValue(Assembly assembly, string key)
        {
            if (TryGetValue(assembly, key, out var value))
            {
                return value;
            }

            throw new Exception($"Could not find a `AssemblyMetadataAttribute` named `{key}` in assembly {assembly.GetName()}.");
        }
    }
}
