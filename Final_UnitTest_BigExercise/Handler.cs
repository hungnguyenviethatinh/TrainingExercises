using Final_UnitTest_BigExercise.Common.Interfaces;
using Final_UnitTest_BigExercise.Core.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public void Run(string threadUrl, string outputPath)
        {
            try
            {
                var result = GetUserWithLikes(threadUrl);
                _resultWriter.WriteToFile(result, outputPath);
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
            }
        }

        public async Task RunAsync(string threadUrl, string outputPath)
        {
            try
            {
                // test code
                Console.WriteLine("RunAsync called.");
                int a = 1;
                int b = 0;
                int c = a / b;
                Console.WriteLine($"{c}");
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
            }
        }

        IDictionary<string, int> GetUserWithLikes(string threadUrl, int pageCount = 3, int page = 1)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();
            if (page > pageCount)
            {
                return result;
            }

            string url = $"{threadUrl}page-{page}";
            var threadPageSource = _webReader.Read(url);
            //int pageCount = _htmlParser.GetPageCount(threadPageSource);

            var posts = _htmlParser.GetPosts(threadPageSource);
            foreach (var post in posts)
            {
                string userName = _htmlParser.GetUserNamePerPost(post);
                string reactionLink = _htmlParser.GetReactionLinkPerPost(post);
                if (!string.IsNullOrEmpty(reactionLink))
                {
                    var postReactionPageSource = _webReader.Read(reactionLink);
                    int reactionCount = _htmlParser.GetReactionCountPerPost(postReactionPageSource);
                    if (!result.ContainsKey(userName))
                    {
                        result.Add(userName, reactionCount);
                    }
                    else
                    {
                        result[userName] += reactionCount;
                    }
                }
                else
                {
                    if (!result.ContainsKey(userName))
                    {
                        result.Add(userName, 0);
                    }
                }

            }

            int nextPage = page + 1;
            var nextPageResult = GetUserWithLikes(threadUrl, pageCount, nextPage);
            foreach(var item in nextPageResult)
            {
                if (!result.ContainsKey(item.Key))
                {
                    result.Add(item);
                }
                else
                {
                    result[item.Key] += item.Value;
                }
            }
            
            return result;
        }

        async Task<IDictionary<string, int>> GetUserWithLikesAsync(string threadUrl)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            // execution code here.

            return result;
        }

        void WriteResultToFile(IDictionary<string, int> result, string outputPath)
        {
            _resultWriter.WriteToFile(result, outputPath);
        }

        HtmlNode GetThreadPageSource(string threadUrl)
        {
            return _webReader.Read(threadUrl);
        }

        async Task<HtmlNode> GetThreadPageSourceAsync(string threadUrl)
        {
            return await _webReader.ReadAsync(threadUrl);
        }
    }
}
