using System;

namespace Week4_UnitTest_C4_LogAnalyzer
{
    public class FakeWebService : IWebService
    {
        public string LastError { get; set; }

        public void LogError(string message)
        {
            LastError = message;
        }
    }

    public class FakeWebService2 : IWebService
    {
        public Exception ToThrow { get; set; }

        public void LogError(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }
}
