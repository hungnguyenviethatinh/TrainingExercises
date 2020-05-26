using NUnit.Framework;
using System;

namespace Week4_UnitTest_C4_LogAnalyzer.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        [Category("UnitTest_C4_LogAnalyzer")]
        public void Analyze_TooShortFileName_CallWebService()
        {
            var mockWebService = new FakeWebService();
            var logAnalyzer = new LogAnalyzer(mockWebService);
            string tooShortFileName = "abc.txt";

            logAnalyzer.Analyze(tooShortFileName);

            StringAssert.Contains("Filename is too short: abc.txt", mockWebService.LastError);
        }
    }

    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        [Category("UnitTest_C4_LogAnalyzer2")]
        public void Analyze_WebServieThrows_SendEmail()
        {
            var stubWebService = new FakeWebService2
            {
                ToThrow = new Exception("fake exception")
            };
            var mockEmailService = new FakeEmailService();
            LogAnalyzer2 logAnalyzer = new LogAnalyzer2(stubWebService, mockEmailService);
            string tooShortFileName = "abc.txt";

            logAnalyzer.Analyze(tooShortFileName);

            var expectedEmail = new EmailInfo
            {
                To = "someone@somewhere",
                Subject = "can't log",
                Body = "fake exception"
            };

            Assert.AreEqual(expectedEmail, mockEmailService.Email);
        }
    }
}
