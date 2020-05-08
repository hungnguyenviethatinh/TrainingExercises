using NUnit.Framework;
using System;

namespace Week4_UnitTest_C3_LogAnalyzer.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        [Category("UnitTest_C3_LogAnalyzer")]
        public void IsValidLogFileName_SupportedFileNameExtension_ReturnTrue()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillBeValid = true
            };

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeExtensionManager);

            bool result = logAnalyzer.IsValidLogFileName("fileName.ext");
            Assert.True(result);
        }

        [Test]
        [Category("UnitTest_C3_LogAnalyzer")]
        public void IsValidLogFileName_ExtManagerThrowsException_ReturnFalse()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillThrow = new Exception("This is fake!")
            };

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeExtensionManager);

            bool result = logAnalyzer.IsValidLogFileName("anyFile.anyExt");

            Assert.False(result);
        }

        [Test]
        [Category("UnitTest_C3_LogAnalyzerUseFactoryMethod")]
        public void OverrideTest()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillBeValid = true
            };

            TestableLogAnalyzer logAnalyzer = new TestableLogAnalyzer(fakeExtensionManager);

            bool result = logAnalyzer.IsValidLogFileName("fileName.ext");
            Assert.True(result);
        }

        [Test]
        [Category("UnitTest_C3_LogAnalyzerUseFactoryMethod_S351")]
        public void OverrideTestWithoutStub()
        {
            TestableLogAnalyzerSection351 logAnalyzer = new TestableLogAnalyzerSection351
            {
                IsSupported = true,
            };

            bool result = logAnalyzer.IsValidLogFileName("fileName.ext");
            Assert.True(result);
        }
    }

    [TestFixture]
    public class LogAnalyzerSection345Tests
    {
        [Test]
        [Category("UnitTest_C3_LogAnalyzer_S345")]
        public void IsValidLogFileName_SupportedFileNameExtension_ReturnTrue()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillBeValid = true
            };

            LogAnalyzerSection345 logAnalyzer = new LogAnalyzerSection345
            {
                ExtensionManager = fakeExtensionManager
            };

            bool result = logAnalyzer.IsValidLogFileName("fileName.ext");
            Assert.True(result);
        }


        [Test]
        [Category("UnitTest_C3_LogAnalyzer_S345")]
        public void IsValidLogFileName_ExtManagerThrowsException_ReturnFalse()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillThrow = new Exception("This is fake!")
            };

            LogAnalyzerSection345 logAnalyzer = new LogAnalyzerSection345
            {
                ExtensionManager = fakeExtensionManager
            };

            bool result = logAnalyzer.IsValidLogFileName("anyFile.anyExt");

            Assert.False(result);
        }

    }

    [TestFixture]
    public class LogAnalyzerSection346Tests
    {
        [Test]
        [Category("UnitTest_C3_LogAnalyzer_S346")]
        public void IsValidLogFileName_SupportedFileNameExtension_ReturnTrue()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillBeValid = true
            };

            ExtensionManagerFactory.SetExtensionManager(fakeExtensionManager);

            LogAnalyzerSection346 logAnalyzer = new LogAnalyzerSection346();

            bool result = logAnalyzer.IsValidLogFileName("fileName.ext");
            Assert.True(result);
        }


        [Test]
        [Category("UnitTest_C3_LogAnalyzer_S346")]
        public void IsValidLogFileName_ExtManagerThrowsException_ReturnFalse()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillThrow = new Exception("This is fake!")
            };

            ExtensionManagerFactory.SetExtensionManager(fakeExtensionManager);

            LogAnalyzerSection346 logAnalyzer = new LogAnalyzerSection346();

            bool result = logAnalyzer.IsValidLogFileName("anyFile.anyExt");

            Assert.False(result);
        }

    }

    class TestableLogAnalyzer : LogAnalyzerUseFactoryMethod
    {
        readonly IExtensionManager _extensionManager;

        public TestableLogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        protected override IExtensionManager GetExtensionManager()
        {
            return _extensionManager;
        }
    }

    class TestableLogAnalyzerSection351 : LogAnalyzerSection351
    {
        public bool IsSupported { get; set; }

        protected override bool IsValid(string fileName)
        {
            return IsSupported;
        }
    }

    class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid { get; set; }
        public Exception WillThrow { get; set; }

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }

            return WillBeValid;
        }
    }
}
