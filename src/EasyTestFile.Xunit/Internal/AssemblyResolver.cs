namespace EasyTestFileXunit.Internal
{
    using System;
    using System.Reflection;

    internal static class AssemblyResolver
    {
        public static Assembly Get(MethodInfo methodInfo)
        {
            Type type = methodInfo.ReflectedType!;
            return type.Assembly;
        }
    }
}
