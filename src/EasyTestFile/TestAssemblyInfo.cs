namespace EasyTestFile;

using System;
using System.Reflection;
using EasyTestFile.DerivedPaths;

/// <summary>
/// 
/// </summary>
public readonly struct TestAssemblyInfo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="assembly"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TestAssemblyInfo(Assembly assembly)
    {
        Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        ProjectDirectory = AttributeReader.GetProjectDirectory(assembly);
        _ = AttributeReader.TryGetSolutionDirectory(assembly, out var solutionDirectory);
        SolutionDirectory = solutionDirectory;
    }

    /// <summary>
    /// Assembly `containing` the TestFiles. This assembly should contain a ProjectReference to the EasyTestFile package.
    /// </summary>
    public Assembly Assembly { get; }

    /// <summary>
    /// The project directory for the given <see cref="Assembly"/> on compile time.
    /// </summary>
    public string ProjectDirectory { get; }

    /// <summary>
    /// The solution directory for the given <see cref="Assembly"/> on compile time. Can be <c>null</c>.
    /// </summary>
    public string? SolutionDirectory { get; }
}