using NSubstitute;
using NUnit.Framework;
using System;

namespace Week4_UnitTest_C5_LogAnalyzer.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        [Category("UnitTest_C5_LogAnalyzer")]
        public void Analyze_LoggerThrows_CallWebService()
        {
            var mockWebService = new FakeWebService();
            var stubLogger = new FakeLogger
            {
                WillThrow = new Exception("fake exception")
            };
            var logAnalyzer = new LogAnalyzer(stubLogger, mockWebService)
            {
                MinNameLength = 8
            };

            string tooShortFileName = "abc.txt";
            logAnalyzer.Analyze(tooShortFileName);

            StringAssert.Contains("fake exception", mockWebService.MessageToWebService);
        }

        [Test]
        [Category("UnitTest_C5_LogAnalyzer")]
        public void Analyze_LoggerThrows_CallWebServiceUseNSub()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger
                .When(logger => logger.LogError(Arg.Compat.Any<string>()))
                .Do(info =>
                {
                    throw new Exception("fake exception");
                });
            var logAnalyzer = new LogAnalyzer(stubLogger, mockWebService)
            {
                MinNameLength = 10
            };

            logAnalyzer.Analyze("short.txt");

            mockWebService
                .Received()
                .Write(Arg.Compat.Is<string>(s => s.Contains("fake exception")));
        }

        [Test]
        [Category("UnitTest_C5_LogAnalyzer")]
        public void Analyze_LoggerThrows_CallWebServiceWithNSubObjectCompare()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger
                .When(logger => logger.LogError(Arg.Compat.Any<string>()))
                .Do(info =>
                {
                    throw new Exception("fake exception");
                });
            var logAnalyzer = new LogAnalyzer(stubLogger, mockWebService)
            {
                MinNameLength = 10
            };

            logAnalyzer.Analyze("short.txt");

            var expected = new ErrorInfo
            {
                Severity = 1000,
                Message = "fake exception"
            };
            mockWebService
                .Received()
                .Write(expected);
        }
    }
}
