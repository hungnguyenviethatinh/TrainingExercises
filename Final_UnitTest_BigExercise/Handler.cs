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
                // test code
                Console.WriteLine("Run called.");
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

        IDictionary<string, int> GetUserWithLikes(string threadUrl)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            // execution code here.

            return result;
        }

        async Task<IDictionary<string, int>> GetUserWithLikesAsync(string threadUrl)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            // execution code here.

            return result;
        }

        void WriteResultToFile(IDictionary<string, int> result, string path)
        {
            _resultWriter.WriteToFile(result, path);
        }

        HtmlNode GetThread(string threadUrl)
        {
            return _webReader.Read(threadUrl);
        }

        async Task<HtmlNode> GetThreadAsync(string threadUrl)
        {
            return await _webReader.ReadAsync(threadUrl);
        }
    }
}
