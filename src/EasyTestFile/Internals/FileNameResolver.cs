namespace EasyTestFile.Internals;

using System.IO;

internal static class FileNameResolver
{
    internal static (string RelativeFilename, string AbsoluteFilename) Find(EasyTestFileSettings settings, TestAssemblyInfo testAssemblyInfo, TestMethodInfo testMethodInfo)
    {
        var physicalFilename = testMethodInfo.SourceFile;
        if (physicalFilename.EndsWith(".cs"))
        {
            physicalFilename = physicalFilename[..(testMethodInfo.SourceFile.Length - 3)];
        }

        var suffix = string.Empty;
        if (!string.IsNullOrWhiteSpace(settings.TestFileNamingSuffix))
        {
            suffix = "." + settings.TestFileNamingSuffix;
        }

        var dotTestFileSuffix = string.Empty;
        if (settings.UseDotTestFileSuffix)
        {
            dotTestFileSuffix = ".testfile";
        }

        physicalFilename = physicalFilename + "_" + testMethodInfo.Method + suffix + dotTestFileSuffix + "." + settings.ExtensionOrTxt();

        if (!string.IsNullOrWhiteSpace(settings.FileName))
        {
            if (string.IsNullOrWhiteSpace(settings.BaseDirectory))
            {
                var testMethodDirectory = testMethodInfo.SourceFileInfo!.Directory.FullName;
                physicalFilename = Path.Combine(testMethodDirectory, settings.FileName!);
            }
            else
            {
                physicalFilename = Path.Combine(testAssemblyInfo.ProjectDirectory, settings.FileName!);
            }
        }

        var relativeFilename = StringHelpers.StringReplaceIgnoreCase(physicalFilename, testAssemblyInfo.ProjectDirectory, string.Empty);

        if (!string.IsNullOrWhiteSpace(settings.BaseDirectory))
        {
            relativeFilename = Path.Combine(settings.BaseDirectory!, relativeFilename);
            physicalFilename = StringHelpers.StringReplaceIgnoreCase(
                physicalFilename,
                testAssemblyInfo.ProjectDirectory,
                Path.Combine(testAssemblyInfo.ProjectDirectory, settings.BaseDirectory!) + Path.DirectorySeparatorChar);
        }

        return (relativeFilename, physicalFilename);
    }
}