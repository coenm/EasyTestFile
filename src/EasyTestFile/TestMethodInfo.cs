namespace EasyTestFile
{
    using System;
    using System.IO;
    using System.Reflection;

    public readonly struct TestMethodInfo
    {
        public TestMethodInfo(MethodInfo info, string sourceFile, string method)
        {
            MethodInfo = info;
            Type = info.ReflectedType!;
            SourceFile = sourceFile;
            Method = method;
            SourceFileInfo = new FileInfo(sourceFile);
        }

        public TestMethodInfo(MethodInfo info)
        {
            MethodInfo = info;
            Type = info.ReflectedType!;
            SourceFile = string.Empty;
            Method = string.Empty;
            SourceFileInfo = null;
        }

        public FileInfo? SourceFileInfo { get; }

        public Type Type { get; }

        public MethodInfo MethodInfo { get; }

        public string SourceFile { get; }

        public string Method { get; }
    }
}
