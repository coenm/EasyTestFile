namespace EasyTestFile.Internals;

using System;

internal static class FileNameResolver
{
    internal static (string RelativeFilename, string AbsoluteFilename) Find(EasyTestFileSettings settings, TestAssemblyInfo testAssemblyInfo, TestMethodInfo testMethodInfo)
    {
        var physicalFilename = testMethodInfo.SanitizedFullSourceFile;
        if (physicalFilename.EndsWith(".cs"))
        {
            physicalFilename = physicalFilename[..(testMethodInfo.SanitizedFullSourceFile.Length - 3)];
        }

        var suffix = string.Empty;
        if (!string.IsNullOrWhiteSpace(settings.TestFileNamingSuffix))
        {
            suffix = "." + settings.TestFileNamingSuffix;
        }

        var dotTestFileSuffix = string.Empty;
        if (settings.UseDotTestFileSuffix)
        {
            dotTestFileSuffix = EasyTestFileConstants.EASY_TEST_FILE_SUFFIX;
        }

        physicalFilename = physicalFilename + "_" + testMethodInfo.Method + suffix + dotTestFileSuffix + "." + settings.ExtensionOrTxt();

        if (!string.IsNullOrWhiteSpace(settings.FileName))
        {
            var testMethodDirectory = testMethodInfo.SanitizedDirectory;
            physicalFilename = DirectorySanitizer.PathCombine(testMethodDirectory, settings.FileName!);
        }
        else
        {
            physicalFilename = DirectorySanitizer.Sanitize(physicalFilename);
        }

        var relativeFilename = StringHelpers.StringReplaceIgnoreCase(physicalFilename, DirectorySanitizer.Sanitize(testAssemblyInfo.ProjectDirectory), string.Empty);

        return (relativeFilename, physicalFilename);
    }
}