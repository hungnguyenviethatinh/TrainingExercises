using HtmlAgilityPack;
using System.Collections.Generic;

namespace FinalUnitTestBigExercise.Core.Interfaces
{
    public interface HtmlParser
    {
        int GetPageCount(HtmlNode threadPageSource);

        IEnumerable<HtmlNode> GetPosts(HtmlNode threadPageSource);

        string GetReactionLinkPerPost(HtmlNode postNode);

        string GetUserNamePerPost(HtmlNode postNode);

        int GetReactionCountPerPost(HtmlNode postReactionPageSource);
    }
}
