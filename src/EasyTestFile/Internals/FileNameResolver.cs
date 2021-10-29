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

        physicalFilename = physicalFilename + "_" + testMethodInfo.Method + suffix + EasyTestFileConstants.EASY_TEST_FILE_SUFFIX + "." + settings.ExtensionOrTxt();
        physicalFilename = DirectorySanitizer.Sanitize(physicalFilename);

        var relativeFilename = StringHelpers.StringReplaceIgnoreCase(physicalFilename, DirectorySanitizer.Sanitize(testAssemblyInfo.ProjectDirectory), string.Empty);

        return (relativeFilename, physicalFilename);
    }
}