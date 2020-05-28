using Final_UnitTest_BigExercise.Core.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Core
{
    public class HtmlParser : IHtmlParser
    {
        public int GetPageCount(HtmlNode threadNode)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, int> GetUserWithLikes(HtmlNode threadNode)
        {
            throw new NotImplementedException();
        }
    }
}
