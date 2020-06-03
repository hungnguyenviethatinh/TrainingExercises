using Final_UnitTest_BigExercise.Common.Interfaces;
using Final_UnitTest_BigExercise.Core.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Tests
{
    [TestFixture]
    public class HandlerTests
    {
        [Test]
        [Category("4. HandlerTests_GetUserLike")]
        public void GetUserLike_Success_ReturnADictionaryOfUserLike()
        {
            var stubLogger = Substitute.For<ILogger>();
            var stubWebReader = Substitute.For<IWebReader>();
            var stubHtmlParser = Substitute.For<IHtmlParser>();
            var stubResultWriter = Substitute.For<IResultWriter>();

            int pageCount = 5;
            int postCount = 10;
            var threadPageSource = Helpers.CreatePageSource(0);
            var posts = Helpers.CreatePosts(postCount);

            stubWebReader
                .Read(Arg.Compat.Is<string>(arg => arg.Contains("http://test.com/")))
                .Returns(threadPageSource);

            stubHtmlParser
                .GetPageCount(threadPageSource)
                .Returns(pageCount);
            stubHtmlParser
                .GetPosts(threadPageSource)
                .Returns(posts);

            for (int index = 0; index < postCount; index++)
            {
                var post = posts.GetElementAt(index);
                stubHtmlParser
                    .GetUserNamePerPost(post)
                    .Returns($"username-{index}");
                stubHtmlParser
                    .GetReactionLinkPerPost(post)
                    .Returns($"reaction-link-{index}");

                var postReactionPageSource = Helpers.CreatePageSource(index + 1);
                stubWebReader
                    .Read($"reaction-link-{index}")
                    .Returns(postReactionPageSource);
                stubHtmlParser
                    .GetReactionCountPerPost(postReactionPageSource)
                    .Returns(index);
            }

            var handler = new Handler(stubLogger, stubWebReader, stubHtmlParser, stubResultWriter);

            var userlike = handler.GetUserLike("http://test.com/");

            var expected = new Dictionary<string, int>();
            for (int count = postCount - 1; count >= 0; count--)
            {
                expected.Add($"username-{count}", count * pageCount);
            }

            Assert.AreEqual(expected, userlike);
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
        public void WriteResult_Success_WriteResultToFile()
        {
            var stubLogger = Substitute.For<ILogger>();
            var stubWebReader = Substitute.For<IWebReader>();
            var stubHtmlParser = Substitute.For<IHtmlParser>();
            var stubResultWriter = Substitute.For<IResultWriter>();

            string path = Helpers.GetAppDirectory() + "\\WriteResult_SuccessExecution_WriteResultToFile.txt";
            var result = new Dictionary<string, int>();
            result.Add("truong5779", 14);
            result.Add("gogomymy", 5);
            result.Add("Newboy", 2);
            result.Add("tu nhi", 1);
            result.Add("kysutach", 1);
            result.Add("data.", 1);
            result.Add("nhaquemexe", 0);
            result.Add("data1", 0);
            result.Add("accord_qng", 0);
            result.Add("TranHai", 0);
            result.Add("vixi69", 0);

            stubResultWriter
                .When(writer => writer.WriteToFile(result, path))
                .Do(info =>
                {
                    Helpers.WriteToFile(result, path);
                });

            var handler = new Handler(stubLogger, stubWebReader, stubHtmlParser, stubResultWriter);

            handler.WriteResult(result, path);

            string[] actual = Helpers.ReadFileLineByLine(path);
            string[] expected =
            {
                "truong5779: 14",
                "gogomymy: 5",
                "Newboy: 2",
                "tu nhi: 1",
                "kysutach: 1",
                "data.: 1",
                "nhaquemexe: 0",
                "data1: 0",
                "accord_qng: 0",
                "TranHai: 0",
                "vixi69: 0"
            };

            Assert.AreEqual(expected, actual);
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
