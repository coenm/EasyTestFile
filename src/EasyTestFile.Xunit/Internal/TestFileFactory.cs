namespace EasyTestFileNunit.Internal
{
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using EasyTestFile;

    internal static class TestFileFactory
    {
        public static TestFile Create(
            EasyTestFileSettings? settings,
            Assembly testAssembly,
            MethodInfo methodInfo,
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
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            MethodInfo methodInfo = MethodInfoResolver.Get();
            Assembly assembly = AssemblyResolver.Get(methodInfo);
            return Create(settings, assembly, methodInfo, sourceFile, method);
        }
    }
}
