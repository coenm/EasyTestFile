namespace EasyTestFileXunit
{
    using System.Reflection;
    using System;

    internal static class AssemblyResolver
    {
        public static Assembly Get(MethodInfo methodInfo)
        {
            Type type = methodInfo.ReflectedType!;
            return type.Assembly;
        }
    }
}
