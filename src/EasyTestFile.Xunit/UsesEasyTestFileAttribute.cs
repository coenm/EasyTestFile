namespace EasyTestFileXunit
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Threading;
    using Xunit.Sdk;

    /// <summary>
    /// Attribute that is applied to a class to enable the usage of EasyTestFile.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UsesEasyTestFileAttribute : BeforeAfterTestAttribute
    {
        private static readonly AsyncLocal<MethodInfo?> _local = new();

        public override void Before(MethodInfo methodUnderTest)
        {
            _local.Value = methodUnderTest;
        }

        public override void After(MethodInfo methodUnderTest)
        {
            _local.Value = null;
        }

        internal static bool TryGet([NotNullWhen(true)] out MethodInfo? info)
        {
            info = _local.Value;
            return info != null;
        }
    }
}
