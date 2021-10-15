using EasyTestFile;

namespace EasyTestFileXunit.Resources.CustomPath
{
    using System.Reflection;

    public static class R
    {
        private static readonly EasyTestFileSettings _settings;

        static R()
        {
            Assembly assembly = typeof(R).Assembly;
            _settings = new EasyTestFileSettings();
            _settings.UseAssembly(assembly);
        }

        public static TestFile FileX => EasyTestFile.Load(_settings);
    }
}
