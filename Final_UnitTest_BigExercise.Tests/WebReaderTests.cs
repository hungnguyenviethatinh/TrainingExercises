using Final_UnitTest_BigExercise.Core;
using NUnit.Framework;
using System;
using System.Net;

namespace Final_UnitTest_BigExercise.Tests
{
    [TestFixture]
    public class WebReaderTests
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
        [Category("1. WebReaderTests_Read")]
        public void Read_ValidAndExistUrl_ReturnHtmlNode(string file)
        {
            var webReader = new WebReader();

            string appDirectory = Helpers.GetAppDirectory();
            string url = $"{appDirectory}\\{file}";

            var htmlNode = webReader.Read(url);

            Assert.NotNull(htmlNode);
        }

        [TestCase("otosaigon.com")]
        [Category("1. WebReaderTests_Read")]
        public void Read_InvalidUrl_Throws(string url)
        {
            var webReader = new WebReader();

            Assert.Throws<UriFormatException>(() => webReader.Read(url));
        }

        [TestCase("https://www.otosaigon.com/non-exist")]
        [Category("1. WebReaderTests_Read")]
        public void Read_NonExistUrl_Throws(string url)
        {
            var webReader = new WebReader();

            Assert.Throws<WebException>(() => webReader.Read(url));
        }
    }
}
