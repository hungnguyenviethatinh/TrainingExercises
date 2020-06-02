using Final_UnitTest_BigExercise.Common.Interfaces;
using Final_UnitTest_BigExercise.Core.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_UnitTest_BigExercise.Tests
{
    [TestFixture]
    public class HandlerTests
    {
        [Test]
        [Category("4. HandlerTests_GetUserLike")]
        public void GetUserLike_SuccessExecution_ReturnADictionaryOfUserLike()
        {
            var stubLogger = Substitute.For<ILogger>();
            var stubWebReader = Substitute.For<IWebReader>();
            var stubHtmlParser = Substitute.For<IHtmlParser>();
            var stubResultWriter = Substitute.For<IResultWriter>();

            var handler = new Handler(stubLogger, stubWebReader, stubHtmlParser, stubResultWriter);

            var result = handler.GetUserLike("");

            var expected = new Dictionary<string, int>();


        }

        [TestCase("otosaigon.com")]
        [TestCase("https://www.otosaigon.com/non-exist")]
        [Category("4. HandlerTests_GetUserLike")]
        public void GetUserLike_WebReaderThrows_CallLogger(string url)
        {
            var mockLogger = Substitute.For<ILogger>();

            var stubHtmlParser = Substitute.For<IHtmlParser>();
            var stubResultWriter = Substitute.For<IResultWriter>();
            var stubWebReader = Substitute.For<IWebReader>();
            stubWebReader
                .When(reader => reader.Read(Arg.Compat.Any<string>()))
                .Do(info =>
                {
                    throw new Exception("fake exception");
                });

            var handler = new Handler(mockLogger, stubWebReader, stubHtmlParser, stubResultWriter);

            handler.GetUserLike(url);

            mockLogger
                .Received()
                .Log(Arg.Compat.Is<string>(message => message.Contains("fake exception")));
        }

        [Test]
        [Category("4. HandlerTests_WriteResult")]
        public void WriteResult()
        {

        }

        [Test]
        [Category("4. HandlerTests_WriteResult")]
        public void WriteResult_ResultWriterThrows_CallLogger()
        {
            var mockLogger = Substitute.For<ILogger>();

            var stubWebReader = Substitute.For<IWebReader>();
            var stubHtmlParser = Substitute.For<IHtmlParser>();
            var stubResultWriter = Substitute.For<IResultWriter>();
            stubResultWriter
                .When(writer => writer.WriteToFile(Arg.Compat.Any<IDictionary<string, int>>(), Arg.Compat.Any<string>()))
                .Do(info =>
                {
                    throw new Exception("fake exception");
                });

            var handler = new Handler(mockLogger, stubWebReader, stubHtmlParser, stubResultWriter);
            var result = new Dictionary<string, int>();
            string path = Helpers.GetAppDirectory() + "\\result.txt";

            handler.WriteResult(result, path);

            mockLogger
                .Received()
                .Log(Arg.Compat.Is<string>(message => message.Contains("fake exception")));
        }
    }
}
