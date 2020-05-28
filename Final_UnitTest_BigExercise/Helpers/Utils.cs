using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Helpers
{
    public static class Utils
    {
        public static HtmlNode QuerySelector(HtmlNode node, string selector)
        {
            return node.QuerySelector(selector);
        }

        public static IEnumerable<HtmlNode> QuerySelectorAll(HtmlNode node, string selector)
        {
            return node.QuerySelectorAll(selector);
        }
    }
}
