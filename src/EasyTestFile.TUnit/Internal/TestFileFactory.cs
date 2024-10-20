namespace EasyTestFileTUnit.Internal
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using global::EasyTestFile;
    using global::EasyTestFile.Internals;

    internal static class TestFileFactory
    {
        public static TestFile Create(
            EasyTestFileSettings? settings,
            Assembly testAssembly,
            MethodInfo? methodInfo,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            return Create(
                settings,
                new TestAssemblyInfo(testAssembly),
                new TestMethodInfo(methodInfo, sourceFile, method));
        }

        public static TestFile Create(
            EasyTestFileSettings? settings,
            TestAssemblyInfo testAssemblyInfo,
            TestMethodInfo testMethodInfo)
        {
            return new TestFile(
                settings,
                testAssemblyInfo,
                testMethodInfo);
        }

        public static TestFile Create(
            Assembly callingAssembly,
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            Assembly assembly = callingAssembly;

            MethodInfo? methodInfo = null;
            if (TestContext.Current != null)
            {
                TestDetails details = TestContext.Current.TestDetails;
                methodInfo = details.MethodInfo;
                assembly = AssemblyResolver.Get(methodInfo!);
            }

            return Create(settings, assembly, methodInfo, sourceFile, method);
        }
    }
}
