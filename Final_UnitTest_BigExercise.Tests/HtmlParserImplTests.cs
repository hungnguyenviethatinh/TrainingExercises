using FinalUnitTestBigExercise.Core;
using NUnit.Framework;
using System;

namespace FinalUnitTestBigExercise.Tests
{
    [TestFixture]
    public class HtmlParserImplImplTests
    {
        [TestCase(@"Resources\4916883\page-1", 5)]
        [TestCase(@"Resources\8973018\page-1", 3)]
        [TestCase(@"Resources\8973162\page-1", 2)]
        [TestCase(@"Resources\false-case", 1)]
        [Category("2.1 HtmlParserImplTests_GetPageCount")]
        public void GetPageCount_NotNullThreadPageSource_ReturnAnInteger(string file, int expected)
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            string appDirectory = Helpers.GetAppDirectory();
            var threadPageSource = Helpers.GetThreadPageSource($"{appDirectory}\\{file}");

            // Action
            int pageCount = HtmlParserImpl.GetPageCount(threadPageSource);

            // Assert
            Assert.AreEqual(pageCount, expected);
        }

        [Test]
        [Category("2.1 HtmlParserImplTests_GetPageCount")]
        public void GetPageCount_NullThreadPageSource_Throws()
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            // Action
            var exception = Assert.Catch<Exception>(() => HtmlParserImpl.GetPageCount(null));

            // Assert
            StringAssert.Contains("Value cannot be null", exception.Message);
        }

        [TestCase(@"Resources\4916883\page-1", 10)]
        [TestCase(@"Resources\4916883\page-2", 10)]
        [TestCase(@"Resources\4916883\page-3", 10)]
        [TestCase(@"Resources\4916883\page-4", 10)]
        [TestCase(@"Resources\4916883\page-5", 10)]
        [TestCase(@"Resources\8973018\page-1", 10)]
        [TestCase(@"Resources\8973018\page-2", 10)]
        [TestCase(@"Resources\8973018\page-3", 5)]
        [TestCase(@"Resources\8973162\page-1", 10)]
        [TestCase(@"Resources\8973162\page-2", 3)]
        [TestCase(@"Resources\false-case", 0)]
        [Category("2.2 HtmlParserImplTests_GetPosts")]
        public void GetPosts_NotNullThreadPageSource_ReturnAnArray(string file, int expected)
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            string appDirectory = Helpers.GetAppDirectory();
            var threadPageSource = Helpers.GetThreadPageSource($"{appDirectory}\\{file}");

            // Action
            var posts = HtmlParserImpl.GetPosts(threadPageSource);

            // Assert
            int postCount = posts.GetElementCount();
            Assert.AreEqual(postCount, expected);
        }

        [Test]
        [Category("2.2 HtmlParserImplTests_GetPosts")]
        public void GetPosts_NullThreadPageSource_Throws()
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            // Action
            var exception = Assert.Catch<Exception>(() => HtmlParserImpl.GetPosts(null));

            // Assert
            StringAssert.Contains("Value cannot be null", exception.Message);
        }

        [TestCase(0, "https://www.otosaigon.com/posts/4916883/reactions")]
        [TestCase(1, "https://www.otosaigon.com/posts/4917032/reactions")]
        [TestCase(2, "https://www.otosaigon.com/posts/4917276/reactions")]
        [TestCase(3, "https://www.otosaigon.com/posts/4918560/reactions")]
        [TestCase(4, "https://www.otosaigon.com/posts/4918681/reactions")]
        [TestCase(5, "https://www.otosaigon.com/posts/4919927/reactions")]
        [TestCase(6, "")]
        [TestCase(7, "https://www.otosaigon.com/posts/4920068/reactions")]
        [TestCase(8, "https://www.otosaigon.com/posts/4920235/reactions")]
        [TestCase(9, "")]
        [Category("2.3 HtmlParserImplTests_GetReactionLinkPerPost")]
        public void GetReactionLinkPerPost_NotNullPostNode_ReturnAString(int postIndex, string expected)
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            string appDirectory = Helpers.GetAppDirectory();
            var threadPageSource = Helpers.GetThreadPageSource($"{appDirectory}\\Resources\\4916883\\page-1");
            var posts = Helpers.GetPosts(threadPageSource);
            var post = posts.GetElementAt(postIndex);

            // Action
            var reactionLink = HtmlParserImpl.GetReactionLinkPerPost(post);

            // Assert
            StringAssert.AreEqualIgnoringCase(reactionLink, expected);
        }

        [Test]
        [Category("2.3 HtmlParserImplTests_GetReactionLinkPerPost")]
        public void GetReactionLinkPerPost_NullPostNode_Throws()
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            // Action
            var exception = Assert.Catch<Exception>(() => HtmlParserImpl.GetReactionLinkPerPost(null));

            // Assert
            StringAssert.Contains("Value cannot be null", exception.Message);
        }

        [TestCase(0, "truong5779")]
        [TestCase(1, "gogomymy")]
        [TestCase(2, "truong5779")]
        [TestCase(3, "Newboy")]
        [TestCase(4, "tu nhi")]
        [TestCase(5, "truong5779")]
        [TestCase(6, "truong5779")]
        [TestCase(7, "kysutach")]
        [TestCase(8, "gogomymy")]
        [TestCase(9, "truong5779")]
        [Category("2.4 HtmlParserImplTests_GetUserNamePerPost")]
        public void GetUserNamePerPost_NotNullPostNode_ReturnAString(int postIndex, string expected)
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            string appDirectory = Helpers.GetAppDirectory();
            var threadPageSource = Helpers.GetThreadPageSource($"{appDirectory}\\Resources\\4916883\\page-1");
            var posts = Helpers.GetPosts(threadPageSource);
            var post = posts.GetElementAt(postIndex);

            // Action
            var userName = HtmlParserImpl.GetUserNamePerPost(post);

            // Assert
            StringAssert.AreEqualIgnoringCase(userName, expected);
        }

        [Test]
        [Category("2.4 HtmlParserImplTests_GetUserNamePerPost")]
        public void GetUserNamePerPost_NullPostNode_Throws()
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            // Action
            var exception = Assert.Catch<Exception>(() => HtmlParserImpl.GetUserNamePerPost(null));

            // Assert
            StringAssert.Contains("Value cannot be null", exception.Message);
        }

        [TestCase(@"Resources\4916883\reaction-1", 10)]
        [TestCase(@"Resources\4916883\reaction-2", 3)]
        [TestCase(@"Resources\4916883\reaction-3", 1)]
        [TestCase(@"Resources\false-case", 0)]
        [Category("2.5 HtmlParserImplTests_GetReactionCountPerPost")]
        public void GetReactionCountPerPost_NotNullPostReactionPageSource_ReturnAnInteger(string file, int expected)
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            string appDirectory = Helpers.GetAppDirectory();
            var postReactionPageSource = Helpers.GetThreadPageSource($"{appDirectory}\\{file}");

            // Action
            int reactionCount = HtmlParserImpl.GetReactionCountPerPost(postReactionPageSource);

            // Assert
            Assert.AreEqual(reactionCount, expected);
        }

        [Test]
        [Category("2.5 HtmlParserImplTests_GetReactionCountPerPost")]
        public void GetReactionCountPerPost_NullPostReactionPageSource_Throws()
        {
            // Arrange
            var HtmlParserImpl = new HtmlParserImpl();

            // Action
            var exception = Assert.Catch<Exception>(() => HtmlParserImpl.GetReactionCountPerPost(null));

            // Assert
            StringAssert.Contains("Value cannot be null", exception.Message);
        }
    }
}
