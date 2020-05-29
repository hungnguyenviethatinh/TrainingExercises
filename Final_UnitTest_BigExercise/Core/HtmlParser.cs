using Final_UnitTest_BigExercise.Core.Interfaces;
using Final_UnitTest_BigExercise.Helpers;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Core
{
    public class HtmlParser : IHtmlParser
    {
        public int GetPageCount(HtmlNode threadPageSource)
        {
            var lastPageNode = Utils.QuerySelector(threadPageSource, "ul.pageNav-main > li:last-child > a");
            if (lastPageNode == null)
            {
                return 1;
            }

            var lastPageText = lastPageNode.InnerText.Trim();

            int pageCount = 1;
            int.TryParse(lastPageText, out pageCount);

            return pageCount;
        }

        public IEnumerable<HtmlNode> GetPosts(HtmlNode threadPageSource)
        {
            return Utils.QuerySelectorAll(threadPageSource, "article.message.message--post");
        }

        public string GetReactionLinkPerPost(HtmlNode postNode)
        {
            var reactionLinkNode = Utils.QuerySelector(postNode, "a.reactionsBar-link");
            if (reactionLinkNode == null)
            {
                return string.Empty;
            }

            string reactionLink = reactionLinkNode.GetAttributeValue("href", string.Empty);
            if (string.IsNullOrWhiteSpace(reactionLink))
            {
                return string.Empty;
            }

            return $"https://www.otosaigon.com{reactionLink}";
        }

        public string GetUserNamePerPost(HtmlNode postNode)
        {
            var userNode = Utils.QuerySelector(postNode, "div.message-userDetails > div.message-name > a");
            var userName = userNode.InnerText.Trim();

            return userName;
        }

        public int GetReactionCountPerPost(HtmlNode postReactionPageSource)
        {
            var reactionNode = Utils.QuerySelector(postReactionPageSource, "a.tabs-tab--reaction0");
            if (reactionNode == null)
            {
                return 0;
            }

            var reactionText = reactionNode.InnerText
                .Trim()
                .Replace("All (", string.Empty)
                .Replace(")", string.Empty);

            int reactionCount = 0;
            int.TryParse(reactionText, out reactionCount);

            return reactionCount;
        }
    }
}
