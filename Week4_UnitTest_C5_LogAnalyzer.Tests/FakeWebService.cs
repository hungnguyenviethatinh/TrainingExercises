using System;

namespace Week4_UnitTest_C5_LogAnalyzer.Tests
{
    public class FakeWebService : IWebService
    {
        public ErrorInfo ErrorInfo { get; set; }
        public string MessageToWebService { get; set; }

        public void Write(ErrorInfo errorInfo)
        {
            ErrorInfo = errorInfo;
        }

        public void Write(string message)
        {
            MessageToWebService = message;
        }
    }
}
