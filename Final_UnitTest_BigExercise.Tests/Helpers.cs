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

        // GetUserLike_Success_OutputUserLikeToFile
        public static HtmlNode CreateFakePageSource(int index)
        {
            return new HtmlNode(HtmlNodeType.Document, new HtmlDocument(), index)
            {
                Name = $"document-{index}"
            };
        }

        public static IEnumerable<HtmlNode> CreateFakePosts(int postCount)
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

        public static string CreateFakeUserName(int index)
        {
            string[] userNames =
            {
                "truong5779",
                "gogomymy",
                "Newboy",
                "tu nhi",
                "kysutach",
                "data.",
                "nhaquemexe",
                "data1",
                "accord_qng",
                "TranHai",
                "vixi69"
            };

            return userNames[index];
        }

        public static string CreateFakeReactionLink(int index)
        {
            string[] reactionLinks =
            {
                "/posts/4916883/reactions",
                "/posts/4917032/reactions",
                "/posts/4917276/reactions",
                "/posts/4918560/reactions",
                "/posts/4918681/reactions",
                "/posts/4919927/reactions",
                "",
                "/posts/4920068/reactions",
                "/posts/4920235/reactions",
                ""
            };

            return reactionLinks[index];
        }

        public static int CreateFakeReactionCount(int index)
        {
            int[] reactionCounts = { 10, 9, 8, 7, 6, 5, 0, 4, 3, 0 };

            return reactionCounts[index];
        }

        public static IDictionary<string, int> CreateExpectedUserLike()
        {
            IDictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("truong5779", 50);
            expected.Add("gogomymy", 45);
            expected.Add("Newboy", 40);
            expected.Add("tu nhi", 35);
            expected.Add("kysutach", 30);
            expected.Add("data.", 25);
            expected.Add("nhaquemexe", 0);
            expected.Add("data1", 20);
            expected.Add("accord_qng", 15);
            expected.Add("TranHai", 0);

            return expected;
        }
        // GetUserLike_Success_OutputUserLikeToFile.

        // WriteResult_Success_WriteResultToFile
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
        // WriteResult_Success_WriteResultToFile.

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
