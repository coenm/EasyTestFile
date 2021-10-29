namespace EasyTestFileNunit.Internal
{
    using System;
    using System.Reflection;
    using EasyTestFileXunit;

    internal static class MethodInfoResolver
    {
        // //var type = info.ReflectedType!;

        public static bool TryGet(out MethodInfo? value)
        {
            return UsesEasyTestFileAttribute.TryGet(out value);
        }

        public static MethodInfo Get()
        {
            if (!TryGet(out MethodInfo? info))
            {
                throw new Exception("Expected Test.TypeInfo and Test.Method to not be null. Raise a Pull Request with a test that replicates this problem.");
            }

            return info!;
        }
    }
}
