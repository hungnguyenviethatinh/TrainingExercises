using FinalUnitTestBigExercise.Core;
using NUnit.Framework;
using System;

namespace FinalUnitTestBigExercise.Tests
{
    [TestFixture]
    public class WebReaderImplTests
    {
        [TestCase(@"Resources\4916883\page-1")]
        [TestCase(@"Resources\4916883\page-2")]
        [TestCase(@"Resources\4916883\page-3")]
        [TestCase(@"Resources\4916883\page-4")]
        [TestCase(@"Resources\4916883\page-5")]
        [TestCase(@"Resources\8973018\page-1")]
        [TestCase(@"Resources\8973018\page-2")]
        [TestCase(@"Resources\8973018\page-3")]
        [TestCase(@"Resources\8973162\page-1")]
        [TestCase(@"Resources\8973162\page-2")]
        [TestCase(@"Resources\false-case")]
        [Category("1. WebReaderImplTests_Read")]
        public void Read_ValidAndExistUrl_ReturnHtmlNode(string file)
        {
            // Arrange
            var webReader = new WebReaderImpl();

            string appDirectory = Helpers.GetAppDirectory();
            string url = $"{appDirectory}\\{file}";

            // Action
            var htmlNode = webReader.Read(url);

            // Assert
            Assert.NotNull(htmlNode);
        }

        [TestCase("otosaigon.com")]
        [Category("1. WebReaderImplTests_Read")]
        public void Read_InvalidUrl_Throws(string url)
        {
            // Arrange
            var webReader = new WebReaderImpl();

            // Action and Assert
            Assert.Throws<UriFormatException>(() => webReader.Read(url));
        }
    }
}
