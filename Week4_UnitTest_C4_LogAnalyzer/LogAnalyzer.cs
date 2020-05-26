using System;

namespace Week4_UnitTest_C4_LogAnalyzer
{
    public class LogAnalyzer
    {
        readonly IWebService _webService;

        public LogAnalyzer(IWebService webService)
        {
            _webService = webService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                _webService.LogError($"Filename is too short: {fileName}");
            }
        }
    }

    public class LogAnalyzer2
    {
        readonly IWebService _webService;
        readonly IEmailService _emailService;

        public LogAnalyzer2(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    _webService.LogError($"Filename is too short: {fileName}");
                }
                catch (Exception exception)
                {
                    _emailService.SendEmail(new EmailInfo
                    {
                        To = "someone@somewhere",
                        Subject = "can't log",
                        Body = exception.Message
                    });
                }
            }
        }
    }
}
