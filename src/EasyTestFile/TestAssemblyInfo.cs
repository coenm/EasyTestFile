namespace EasyTestFile
{
    using System;
    using System.Reflection;
    using EasyTestFile.DerivedPaths;

    public readonly struct TestAssemblyInfo
    {
        public TestAssemblyInfo(Assembly assembly)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            ProjectDirectory = AttributeReader.GetProjectDirectory(assembly);
            _ = AttributeReader.TryGetSolutionDirectory(assembly, out var solutionDirectory);
            SolutionDirectory = solutionDirectory;
        }

        public Assembly Assembly { get; }

        public string ProjectDirectory { get; }

        public string? SolutionDirectory { get; }
    }
}
