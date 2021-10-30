namespace EasyTestFile.Tests;

public class TestFileTest
{
    public void Ctor()
    {
        EasyTestFileSettings settings = new EasyTestFileSettings();
        TestAssemblyInfo testAssemblyInfo = new TestAssemblyInfo(typeof(TestFileTest).Assembly);
        TestMethodInfo testMethodInfo = new TestMethodInfo(); //
        var sut = new TestFile(settings, testAssemblyInfo, testMethodInfo);
    }
}