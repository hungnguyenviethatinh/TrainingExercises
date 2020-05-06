using Week4_UnitTest_LogAnalyzer.Helpers;
using System;

namespace Week4_UnitTest_LogAnalyzer
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException(ExceptionMessage.FileNameHasToBeProvided);
            }

            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;

            return true;
        }
    }
}
