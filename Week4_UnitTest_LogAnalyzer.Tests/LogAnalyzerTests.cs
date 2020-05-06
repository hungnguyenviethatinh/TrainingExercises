using Week4_UnitTest_LogAnalyzer.Helpers;
using NUnit.Framework;
using System;

namespace Week4_UnitTest_LogAnalyzer.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TestCase("filewithbadextension.foo", false)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.SLF", true)]
        [Category("Check FileName Extension")]
        public void IsValidLogFileName_VariousExtensions_CheckThem(string file, bool expected)
        {
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            bool actual = logAnalyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Expected Exception")]
        public void IsValidLogFileName_EmptyFileName_ThrowException()
        {
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            Exception exception = Assert.Catch<Exception>(() => logAnalyzer.IsValidLogFileName(string.Empty));

            StringAssert.Contains(ExceptionMessage.FileNameHasToBeProvided, exception.Message);
        }

        [Test]
        [Ignore("This test is redundant!")]
        [Category("Ignoring Test")]
        public void IsValidLogFileName_ValidExtensionLowerCase_ReturnTrue()
        {
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            bool actual = logAnalyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.That(actual, Is.True);
        }

        [TestCase("filewithbadextension.foo", false)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.SLF", true)]
        [Category("State-based Test")]
        public void IsValidLogFileName_WhenCalled_ChangeWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            logAnalyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, logAnalyzer.WasLastFileNameValid);
        }

        static LogAnalyzer MakeLogAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
