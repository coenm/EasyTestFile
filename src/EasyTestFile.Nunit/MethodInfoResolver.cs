namespace EasyTestFileNunit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using global::EasyTestFile;
using NUnit.Framework;
using NUnit.Framework.Internal;

internal static class MethodInfoResolver
{
    private static readonly FieldInfo _field = typeof(TestContext.TestAdapter).GetField("_test", BindingFlags.Instance | BindingFlags.NonPublic)
                                               ??
                                               throw new InternalErrorRaisePullRequestException("Could not find field `_test` on TestContext.TestAdapter.");

    public static bool TryGet([NotNullWhen(true)] out MethodInfo? methodInfo)
    {
        TestContext context = TestContext.CurrentContext;
        TestContext.TestAdapter adapter = context.Test;
        var test = (Test)_field.GetValue(adapter)!;

        if (test.TypeInfo == null || test.Method is null)
        {
            methodInfo = null;
            return false;
        }

        // Type type = test.TypeInfo!.Type;
        methodInfo = test.Method!.MethodInfo;
        return true;
    }

    public static MethodInfo Get()
    {
        if (!TryGet(out MethodInfo? methodInfo))
        {
            throw new InternalErrorRaisePullRequestException("Expected Test.TypeInfo and Test.Method to not be null.");
        }

        return methodInfo!;
    }
}