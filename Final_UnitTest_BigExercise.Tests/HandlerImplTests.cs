using FinalUnitTestBigExercise.Core.Interfaces;
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

            string threadUrl = "http://test.com/";
            int pageCount = 5;
            int postCount = 10;
            var threadPageSource = Helpers.CreateFakePageSource(0);
            var posts = Helpers.CreateFakePosts(postCount);

            stubWebReader
                .Read(Arg.Compat.Is<string>(arg => arg.Contains(threadUrl)))
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

                string userName = Helpers.CreateFakeUserName(index);
                stubHtmlParser
                    .GetUserNamePerPost(post)
                    .Returns(userName);

                string reactionLink = Helpers.CreateFakeReactionLink(index);
                stubHtmlParser
                    .GetReactionLinkPerPost(post)
                    .Returns(reactionLink);

                var postReactionPageSource = Helpers.CreateFakePageSource(index);
                stubWebReader
                    .Read(reactionLink)
                    .Returns(postReactionPageSource);

                var reactionCount = Helpers.CreateFakeReactionCount(index);
                stubHtmlParser
                    .GetReactionCountPerPost(postReactionPageSource)
                    .Returns(reactionCount);
            }

            var handler = new HandlerImpl(stubWebReader, stubHtmlParser, stubResultWriter);

            // Action
            var userLike = handler.GetUserLike(threadUrl);

            // Assert
            var expected = Helpers.CreateExpectedUserLike();

            Assert.AreEqual(expected, userLike);
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

            string path = Helpers.GetAppDirectory() + "\\WriteResult_Success_WriteResultToFile.txt";
            var result = Helpers.CreateFakeResult();

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
            string[] expected = Helpers.CreateExpectedResult();

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
