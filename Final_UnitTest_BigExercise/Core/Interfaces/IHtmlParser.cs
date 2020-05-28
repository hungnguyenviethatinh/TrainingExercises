using HtmlAgilityPack;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Core.Interfaces
{
    public interface IHtmlParser
    {
        int GetPageCount(HtmlNode threadNode);
        IDictionary<string, int> GetUserWithLikes(HtmlNode threadNode);
    }
}
