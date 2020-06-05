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
            IDictionary<string, int> result = new Dictionary<string, int>();

            int pageCount = GetPageCount(threadUrl);
            for (int page = 1; page <= pageCount; page++)
            {
                var userLike = GetUserLikePerPage(threadUrl, page);
                result.Merge(userLike);
            }

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

        IDictionary<string, int> GetUserLikePerPage(string threadUrl, int page)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            string url = $"{threadUrl}page-{page}";
            var threadPageSource = webReader.Read(url);

            var posts = htmlParser.GetPosts(threadPageSource);
            foreach (var post in posts)
            {
                string userName = htmlParser.GetUserNamePerPost(post);
                int reactionCount = GetReactionCountPerPost(post);

                result.AddPair(userName, reactionCount);
            }

            return result;
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
