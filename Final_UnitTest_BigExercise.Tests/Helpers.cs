using Final_UnitTest_BigExercise.Helpers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Final_UnitTest_BigExercise.Tests
{
    public static class Helpers
    {
        public static string GetAppDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static HtmlNode GetThreadPageSource(string file)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(file);

            return htmlDocument.DocumentNode;
        }

        public static IEnumerable<HtmlNode> GetPosts(HtmlNode threadPageSource)
        {
            return Utils.QuerySelectorAll(threadPageSource, Constants.PostNodeSelector);
        }

        public static int GetElementCount<T>(this IEnumerable<T> nodes)
        {
            return nodes.Count();
        }

        public static T GetElementAt<T>(this IEnumerable<T> nodes, int index)
        {
            return nodes.ElementAt(index);
        }

        public static bool FileExists(string file)
        {
            return File.Exists(file);
        }

        public static bool IsEmptyFile(string file)
        {
            var fileInfo = new FileInfo(file);

            return fileInfo.Length == 0;
        }

        public static string[] ReadFileLineByLine(string file)
        {
            var lines = File.ReadLines(file);

            return lines.ToArray();
        }
    }
}
