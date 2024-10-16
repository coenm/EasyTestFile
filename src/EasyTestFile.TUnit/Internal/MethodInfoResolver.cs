namespace EasyTestFileTUnit.Internal
{
    using System.Reflection;
    using EasyTestFileTUnit;

    internal static class MethodInfoResolver
    {
        public static bool TryGet(out MethodInfo? value)
        {
            TestDetails details = TestContext.Current!.TestDetails;
            // var type = details.ClassType;
            // var classArguments = details.TestClassArguments;
            // var methodArguments = details.TestMethodArguments;
            MethodInfo method = details.MethodInfo;
            value = method;
            return true;
        }
    }
}
