using FinalUnitTestBigExercise.Core.Interfaces;
using HtmlAgilityPack;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FinalUnitTestBigExercise.Tests
{
    [TestFixture]
    public class HandlerImplTests
    {
        [Test]
        [Category("4. HandlerImplTests_GetUserLike")]
        public void GetUserLike_Success_OutputUserLikeToFile()
        {
            // Arrange
            var stubWebReader = Substitute.For<WebReader>();
            var stubHtmlParser = Substitute.For<HtmlParser>();
            var stubResultWriter = Substitute.For<ResultWriter>();

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

                var postReactionPageSource = Helpers.CreatePageSource(index + 1);
                if (index != 6 && index != 9)
                {
                    // Case 0, 1, 2, 3, 4, 5, 7, 8 have reaction link
                    stubHtmlParser
                        .GetReactionLinkPerPost(post)
                        .Returns($"reaction-link-{index}");

                    stubWebReader
                        .Read($"reaction-link-{index}")
                        .Returns(postReactionPageSource);
                    stubHtmlParser
                        .GetReactionCountPerPost(postReactionPageSource)
                        .Returns(index);
                }
                else
                {
                    // Case 6 and 9 have no reaction link
                    stubHtmlParser
                        .GetReactionLinkPerPost(post)
                        .Returns("");

                    stubWebReader
                        .Read("")
                        .Returns(postReactionPageSource);
                    stubHtmlParser
                        .GetReactionCountPerPost(postReactionPageSource)
                        .Returns(0);
                }
            }

            var handler = new HandlerImpl(stubWebReader, stubHtmlParser, stubResultWriter);

            // Action
            var userlike = handler.GetUserLike("http://test.com/");

            // Assert
            var expected = new Dictionary<string, int>();
            for (int count = postCount - 1; count >= 0; count--)
            {
                if (count != 6 && count != 9)
                {
                    expected.Add($"username-{count}", count * pageCount);
                }
            }
            expected.Add($"username-{6}", 0);
            expected.Add($"username-{9}", 0);

            Assert.AreEqual(expected, userlike);
        }

        [TestCase("otosaigon.com")]
        [Category("4. HandlerImplTests_GetUserLike")]
        public void GetUserLike_WebReaderError_Throws(string url)
        {
            // Arrange
            var stubHtmlParser = Substitute.For<HtmlParser>();
            var stubResultWriter = Substitute.For<ResultWriter>();
            var stubWebReader = Substitute.For<WebReader>();
            stubWebReader
                .When(reader => reader.Read(Arg.Compat.Any<string>()))
                .Do(info =>
                {
                    throw new Exception("fake exception");
                });

            var handler = new HandlerImpl(stubWebReader, stubHtmlParser, stubResultWriter);

            // Action
            var exception = Assert.Catch<Exception>(() => handler.GetUserLike(url));

            // Assert
            StringAssert.Contains("fake exception", exception.Message);
        }

        [Test]
        [Category("4. HandlerImplTests_WriteResult")]
        public void WriteResult_Success_WriteResultToFile()
        {
            // Arrange
            var stubWebReader = Substitute.For<WebReader>();
            var stubHtmlParser = Substitute.For<HtmlParser>();
            var stubResultWriter = Substitute.For<ResultWriter>();

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

            var handler = new HandlerImpl(stubWebReader, stubHtmlParser, stubResultWriter);

            // Action
            handler.WriteResult(result, path);

            // Assert
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
        [Category("4. HandlerImplTests_WriteResult")]
        public void WriteResult_ResultWriterError_Throws()
        {
            // Arrange
            var stubWebReader = Substitute.For<WebReader>();
            var stubHtmlParser = Substitute.For<HtmlParser>();
            var stubResultWriter = Substitute.For<ResultWriter>();
            stubResultWriter
                .When(writer => writer.WriteToFile(Arg.Compat.Any<IDictionary<string, int>>(), Arg.Compat.Any<string>()))
                .Do(info =>
                {
                    throw new Exception("fake exception");
                });

            var handler = new HandlerImpl(stubWebReader, stubHtmlParser, stubResultWriter);
            var result = new Dictionary<string, int>();
            string path = Helpers.GetAppDirectory() + "\\result.txt";

            // Action
            var exception = Assert.Catch<Exception>(() => handler.WriteResult(result, path));

            // Assert
            StringAssert.Contains("fake exception", exception.Message);
        }
    }
}
