using FinalUnitTestBigExercise.Core.Interfaces;
using FinalUnitTestBigExercise.Helpers;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace FinalUnitTestBigExercise
{
    public class HandlerImpl : Handler
    {
        readonly WebReader webReader;
        readonly HtmlParser htmlParser;
        readonly ResultWriter resultWriter;

        public HandlerImpl(WebReader webReader, HtmlParser htmlParser, ResultWriter resultWriter)
        {
            this.webReader = webReader;
            this.htmlParser = htmlParser;
            this.resultWriter = resultWriter;
        }

        public IDictionary<string, int> GetUserLike(string threadUrl)
        {
            int pageCount = GetPageCount(threadUrl);
            var result = GetUserLike(threadUrl, pageCount, 1);

            return result
                .OrderByDescending(pair => pair.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public void WriteResult(IDictionary<string, int> result, string outputPath)
        {
            resultWriter.WriteToFile(result, outputPath);
        }

        int GetPageCount(string threadUrl)
        {
            var threadPageSource = webReader.Read(threadUrl);
            int pageCount = htmlParser.GetPageCount(threadPageSource);

            return pageCount;
        }

        IDictionary<string, int> GetUserLike(string threadUrl, int pageCount, int page)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();
            if (page > pageCount)
            {
                return result;
            }

            string url = $"{threadUrl}page-{page}";
            var threadPageSource = webReader.Read(url);

            var posts = htmlParser.GetPosts(threadPageSource);
            foreach (var post in posts)
            {
                string userName = htmlParser.GetUserNamePerPost(post);
                int reactionCount = GetReactionCountPerPost(post);

                result.AddPair(userName, reactionCount);
            }

            var nextPageResult = GetUserLike(threadUrl, pageCount, page + 1);

            return result.Merge(nextPageResult);
        }

        int GetReactionCountPerPost(HtmlNode postNode)
        {
            int reactionCount = 0;

            string reactionLink = htmlParser.GetReactionLinkPerPost(postNode);
            if (!string.IsNullOrEmpty(reactionLink))
            {
                var postReactionPageSource = webReader.Read(reactionLink);
                reactionCount = htmlParser.GetReactionCountPerPost(postReactionPageSource);
            }

            return reactionCount;
        }
    }
}
