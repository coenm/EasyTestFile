namespace EasyTestFile.Tests;

using System.Reflection;
using System.Runtime.CompilerServices;

static class TestMethodInfoFactory
{
    public static TestMethodInfo CreateTestMethodInfo(MethodBase getCurrentMethod, [CallerMemberName] string member = "", [CallerFilePath] string file = "")
    {
        return new TestMethodInfo((MethodInfo)getCurrentMethod, file, member);
    }
}