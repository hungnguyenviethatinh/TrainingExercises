using Final_UnitTest_BigExercise.Common.Interfaces;
using Final_UnitTest_BigExercise.Core.Interfaces;
using Final_UnitTest_BigExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_UnitTest_BigExercise
{
    public class Handler : IHandler
    {
        readonly ILogger _logger;
        readonly IWebReader _webReader;
        readonly IHtmlParser _htmlParser;
        readonly IResultWriter _resultWriter;

        public Handler(ILogger logger, IWebReader webReader, IHtmlParser htmlParser, IResultWriter resultWriter)
        {
            _logger = logger;
            _webReader = webReader;
            _htmlParser = htmlParser;
            _resultWriter = resultWriter;
        }

        public IDictionary<string, int> GetUserLike(string threadUrl)
        {
            try
            {
                int pageCount = 5; // GetPageCount(threadUrl);
                var result = GetUserLike(threadUrl, pageCount, 1);

                return result
                    .OrderByDescending(pair => pair.Value)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
            }

            return new Dictionary<string, int>();
        }

        public void WriteResult(IDictionary<string, int> result, string outputPath)
        {
            try
            {
                _resultWriter.WriteToFile(result, outputPath);
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
            }
        }

        int GetPageCount(string threadUrl)
        {
            var threadPageSource = _webReader.Read(threadUrl);
            int pageCount = _htmlParser.GetPageCount(threadPageSource);

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
            var threadPageSource = _webReader.Read(url);

            var posts = _htmlParser.GetPosts(threadPageSource);
            foreach (var post in posts)
            {
                string userName = _htmlParser.GetUserNamePerPost(post);
                string reactionLink = _htmlParser.GetReactionLinkPerPost(post);
                if (!string.IsNullOrEmpty(reactionLink))
                {
                    var postReactionPageSource = _webReader.Read(reactionLink);
                    int reactionCount = _htmlParser.GetReactionCountPerPost(postReactionPageSource);

                    result.AddPair(userName, reactionCount);
                }
                else
                {
                    result.AddPair(userName, 0);
                }
            }

            var nextPageResult = GetUserLike(threadUrl, pageCount, page + 1);

            return result.Merge(nextPageResult);
        }
    }
}
