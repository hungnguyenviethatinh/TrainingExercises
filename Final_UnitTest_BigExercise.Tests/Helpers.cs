using FinalUnitTestBigExercise.Helpers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinalUnitTestBigExercise.Tests
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

        public static HtmlNode CreatePageSource(int index)
        {
            return new HtmlNode(HtmlNodeType.Document, new HtmlDocument(), index)
            {
                Name = $"document-{index}"
            };
        }

        public static IEnumerable<HtmlNode> CreatePosts(int postCount)
        {
            var posts = new List<HtmlNode>();

            for (int index = 0; index < postCount; index++)
            {
                var post = new HtmlNode(HtmlNodeType.Element, new HtmlDocument(), index)
                {
                    Name = $"article-{index}"
                };

                posts.Add(post);
            }

            return posts;
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

        public static void WriteToFile(IDictionary<string, int> result, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (var pair in result)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
