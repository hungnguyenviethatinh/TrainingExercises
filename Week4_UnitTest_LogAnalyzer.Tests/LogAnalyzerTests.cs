using Week4_UnitTest_LogAnalyzer.Helpers;
using NUnit.Framework;
using System;

namespace Week4_UnitTest_LogAnalyzer.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        LogAnalyzer _logAnalyzer;

        [OneTimeSetUp]
        public void SetUp()
        {
            _logAnalyzer = new LogAnalyzer();
        }

        [TestCase("filewithbadextension.foo", false)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.SLF", true)]
        [Category("Check FileName Extension")]
        public void IsValidLogFileName_VariousExtensions_CheckThem(string file, bool expected)
        {
            bool actual = _logAnalyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Expected Exception")]
        public void IsValidLogFileName_EmptyFileName_ThrowException()
        {
            Exception exception = Assert.Catch<Exception>(() => _logAnalyzer.IsValidLogFileName(string.Empty));

            StringAssert.Contains(ExceptionMessage.FileNameHasToBeProvided, exception.Message);
        }

        [Test]
        [Ignore("This test is redundant!")]
        [Category("Ignoring Test")]
        public void IsValidLogFileName_ValidExtensionLowerCase_ReturnTrue()
        {
            bool actual = _logAnalyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.That(actual, Is.True);
        }

        [TestCase("filewithbadextension.foo", false)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.SLF", true)]
        [Category("State-based Test")]
        public void IsValidLogFileName_WhenCalled_ChangeWasLastFileNameValid(string file, bool expected)
        {
            _logAnalyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, _logAnalyzer.WasLastFileNameValid);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _logAnalyzer = null;
        }
    }
}
