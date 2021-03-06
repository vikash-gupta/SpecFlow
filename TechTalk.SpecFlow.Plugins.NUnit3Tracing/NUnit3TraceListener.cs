using NUnit.Framework;
using TechTalk.SpecFlow.Tracing;

namespace NUnit3Tracing.SpecFlowPlugin
{
    public class NUnit3TraceListener : ITraceListener
    {

        public void WriteTestOutput(string message)
        {
            message = FormatMessage(message);
            TestContext.Out.WriteLine(message);
        }

        public void WriteToolOutput(string message)
        {
            message = FormatMessage(message);
            TestContext.Out.WriteLine($"-> {message}");
        }

        private string FormatMessage(string message)
        {
            var testName = GetCurrentTestCaseName();
            return $"#[{testName}]: {message}";
        }

        private string GetCurrentTestCaseName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }
    }
}
