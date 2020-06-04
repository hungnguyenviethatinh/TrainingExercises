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

        public static IDictionary<string, int> CreateExpected(int pageCount, int postCount)
        {
            IDictionary<string, int> expected = new Dictionary<string, int>();
            for (int count = postCount - 1; count >= 0; count--)
            {
                if (count != 6 && count != 9)
                {
                    expected.Add($"username-{count}", count * pageCount);
                }
            }

            expected.Add($"username-{6}", 0);
            expected.Add($"username-{9}", 0);

            return expected;
        }

        public static IDictionary<string, int> CreateFakeResult()
        {
            IDictionary<string, int> result = new Dictionary<string, int>();
            result.Add("truong5779", 14);
            result.Add("gogomymy", 5);
            result.Add("Newboy", 2);
            result.Add("tu nhi", 1);
            result.Add("kysutach", 1);
            result.Add("data.", 1);
            result.Add("nhaquemexe", 0);
            result.Add("data1", 0);
            result.Add("accord_qng", 0);
            result.Add("TranHai", 0);
            result.Add("vixi69", 0);

            return result;
        }

        public static string[] CreateExpectedResult()
        {
            return new string[]
            {
                "truong5779: 14",
                "gogomymy: 5",
                "Newboy: 2",
                "tu nhi: 1",
                "kysutach: 1",
                "data.: 1",
                "nhaquemexe: 0",
                "data1: 0",
                "accord_qng: 0",
                "TranHai: 0",
                "vixi69: 0"
            };
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
