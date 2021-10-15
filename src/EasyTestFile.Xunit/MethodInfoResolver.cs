namespace EasyTestFileXunit
{
    using System;
    using System.Reflection;

    internal static class MethodInfoResolver
    {
        // //var type = info.ReflectedType!;

        public static bool TryGet(out MethodInfo? value)
        {
            return (UsesEasyTestFileAttribute.TryGet(out value));
        }

        public static MethodInfo Get()
        {
            if (!TryGet(out MethodInfo? info))
            {
                throw new Exception("Could not grab MethodInfo");
            }

            return info!;
        }
    }
}
