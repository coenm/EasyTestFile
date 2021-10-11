namespace EasyTestFileXunit
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Threading;
    using Xunit.Sdk;

    [AttributeUsage(AttributeTargets.Class)]
    public class UsesEasyTestFileAttribute : BeforeAfterTestAttribute
    {
        private static readonly AsyncLocal<MethodInfo?> Local = new AsyncLocal<MethodInfo?>();

        public override void Before(MethodInfo methodUnderTest)
        {
            Local.Value = methodUnderTest;
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Local.Value = null;
        }

        internal static bool TryGet([NotNullWhen(true)] out MethodInfo? info)
        {
            info = Local.Value;
            return info != null;
        }
    }
}
