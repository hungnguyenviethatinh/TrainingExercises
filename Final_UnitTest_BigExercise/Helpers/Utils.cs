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

        public static IDictionary<string, int> Merge(this IDictionary<string, int> destination, IDictionary<string, int> source)
        {
            foreach (var pair in source)
            {
                destination.AddPair(pair.Key, pair.Value);
            }

            return destination;
        }

        public static void AddPair(this IDictionary<string, int> destination, string key, int value)
        {
            if (!destination.ContainsKey(key))
            {
                destination.Add(key, value);
            }
            else
            {
                destination[key] += value;
            }
        }
    }
}
