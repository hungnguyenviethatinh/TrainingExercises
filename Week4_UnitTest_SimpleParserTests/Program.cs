using System;

namespace Week4_UnitTest_SimpleParserTests
{
    static class Program
    {
        static void Main()
        {
            try
            {
                SimpleParserTests.TestReturnZeroWhenEmptyString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            try
            {
                SimpleParserTests.TestReturnSingleNumber();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("All test cases have been tested. Problem if have any, shown above!");
            Console.ReadLine();
        }
    }
}
