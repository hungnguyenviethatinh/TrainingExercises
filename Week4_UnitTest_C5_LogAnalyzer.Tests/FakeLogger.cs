using System;

namespace Week4_UnitTest_C5_LogAnalyzer.Tests
{
    public class FakeLogger : ILogger
    {
        public Exception WillThrow { get; set; }
        public string LoggerGotMessage { get; set; }

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }
    }
}
