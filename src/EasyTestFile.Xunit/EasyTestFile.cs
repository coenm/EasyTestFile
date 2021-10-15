namespace EasyTestFileXunit
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using global::EasyTestFile;

    public static class EasyTestFile
    {
        public static TestFile Load(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            //Assembly callingAssembly = Assembly.GetExecutingAssembly();
            return TestFileFactory.Create(callingAssembly, settings, sourceFile, method);
        }

        public static async Task<string> LoadAsText(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            TestFile testFile = TestFileFactory.Create(callingAssembly, settings, sourceFile, method);
            return await testFile.AsText();
        }

        public static Task<Stream> LoadAsStream(
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            TestFile testFile = TestFileFactory.Create(callingAssembly, settings, sourceFile, method);
            return Task.FromResult(testFile.AsStream());
        }

        public static TestFile Load(
            string filename,
            EasyTestFileSettings? settings = null,
            [CallerFilePath] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var s = new EasyTestFileSettings(settings);
            s.UseFileName(filename);
            return TestFileFactory.Create(callingAssembly, s, sourceFile, method);
        }


        public static async Task<string> LoadAsText(
            string filename,
            EasyTestFileSettings? settings = null,
            [CallerFilePathAttribute] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var s = new EasyTestFileSettings(settings);
            s.UseFileName(filename);
            TestFile testFile = TestFileFactory.Create(callingAssembly, s, sourceFile, method);
            return await testFile.AsText();
        }

        public static Task<Stream> LoadAsStream(
            string filename,
            EasyTestFileSettings? settings = null,
            [CallerFilePathAttribute] string sourceFile = "",
            [CallerMemberName] string method = "")
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var s = new EasyTestFileSettings(settings);
            s.UseFileName(filename);
            TestFile testFile = TestFileFactory.Create(callingAssembly, s, sourceFile, method);
            return Task.FromResult(testFile.AsStream());
        }
    }
}
