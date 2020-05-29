using HtmlAgilityPack;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Core.Interfaces
{
    public interface IHtmlParser
    {
        int GetPageCount(HtmlNode threadPageSource);

        IEnumerable<HtmlNode> GetPosts(HtmlNode threadPageSource);

        string GetReactionLinkPerPost(HtmlNode postNode);

        string GetUserNamePerPost(HtmlNode postNode);

        int GetReactionCountPerPost(HtmlNode postReactionPageSource);
    }
}
