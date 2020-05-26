using System;

namespace Week4_UnitTest_C5_LogAnalyzer
{
    public class LogAnalyzer
    {
        readonly ILogger _logger;
        readonly IWebService _webService;

        public LogAnalyzer(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError($"Filename is too short: {fileName}");
                }
                catch (Exception exception)
                {
                    _webService.Write("Error from Logger: " + exception);
                    _webService.Write(new ErrorInfo
                    {
                        Severity = 1000,
                        Message = "fake exception"
                    });
                }
            }
        }
    }
}
