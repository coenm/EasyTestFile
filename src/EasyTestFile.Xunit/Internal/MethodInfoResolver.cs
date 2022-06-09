namespace EasyTestFileXunit.Internal
{
    using System.Reflection;
    using EasyTestFileXunit;

    internal static class MethodInfoResolver
    {
        public static bool TryGet(out MethodInfo? value)
        {
            return UsesEasyTestFileAttribute.TryGet(out value);
        }
    }
}
