namespace EasyTestFileXunit.Tests.Samples
{
    using System.Threading.Tasks;
    using Xunit;

// begin-snippet: XUnitAttributeUsage
    [UsesEasyTestFile]
    public class TestClass1
    {
        // The attribute is required when using XUnit.
    }
// end-snippet
}