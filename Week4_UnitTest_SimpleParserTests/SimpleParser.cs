using System;
using System.Linq;
using Week4_UnitTest_SimpleParserTests.Helpers;

namespace Week4_UnitTest_SimpleParserTests
{
    public class SimpleParser
    {
        public int ParseAndSum(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            if (!numbers.Contains(','))
            {
                return int.Parse(numbers);
            }

            throw new InvalidOperationException(TestOutputMessage.OnlyHandleZeroOrOneNumber);
        }
    }
}
