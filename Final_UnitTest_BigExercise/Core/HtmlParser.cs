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
            int pageCount = 1;
            var lastPageNode = Utils.QuerySelector(threadPageSource, Constants.LastPageNodeSelector);
            if (lastPageNode != null)
            {
                var lastPageText = lastPageNode.InnerText.Trim();

                int.TryParse(lastPageText, out pageCount);
            }

            return pageCount;
        }

        public IEnumerable<HtmlNode> GetPosts(HtmlNode threadPageSource)
        {
            return Utils.QuerySelectorAll(threadPageSource, Constants.PostNodeSelector);
        }

        public string GetReactionLinkPerPost(HtmlNode postNode)
        {
            var reactionLinkNode = Utils.QuerySelector(postNode, Constants.ReactionLinkNodeSelector);
            if (reactionLinkNode == null)
            {
                return string.Empty;
            }

            string reactionLink = reactionLinkNode.GetAttributeValue("href", string.Empty);
            if (string.IsNullOrWhiteSpace(reactionLink))
            {
                return string.Empty;
            }

            return $"{Constants.BaseUrl}{reactionLink}";
        }

        public string GetUserNamePerPost(HtmlNode postNode)
        {
            string userName = string.Empty;
            var userNode = Utils.QuerySelector(postNode, Constants.UserNodeSelector);
            if (userNode != null)
            {
                userName = userNode.InnerText.Trim();
            }

            return userName;
        }

        public int GetReactionCountPerPost(HtmlNode postReactionPageSource)
        {
            int reactionCount = 0;
            var reactionNode = Utils.QuerySelector(postReactionPageSource, Constants.ReactionNodeSelector);
            if (reactionNode != null)
            {
                var reactionText = reactionNode.InnerText
                .Trim()
                .Replace(Constants.PrefixReactionText, string.Empty)
                .Replace(Constants.SubfixReactionText, string.Empty);

                int.TryParse(reactionText, out reactionCount);
            }

            return reactionCount;
        }
    }
}
