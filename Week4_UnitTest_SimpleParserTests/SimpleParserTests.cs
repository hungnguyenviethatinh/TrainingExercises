using System;
using System.Reflection;
using Week4_UnitTest_SimpleParserTests.Helpers;

namespace Week4_UnitTest_SimpleParserTests
{
    public static class SimpleParserTests
    {
        static SimpleParser _simpleParser = new SimpleParser();

        public static void TestReturnZeroWhenEmptyString()
        {
            string testMethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                int result = _simpleParser.ParseAndSum(string.Empty);
                if (result != 0)
                {
                    TestUtil.ShowProblem(testMethodName, TestOutputMessage.ShouldReturnZero);
                }
            }
            catch (Exception exception)
            {
                TestUtil.ShowProblem(testMethodName, exception.ToString());
            }
        }

        public static void TestReturnSingleNumber()
        {
            string testMethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                int result = _simpleParser.ParseAndSum("7");
                if (result != 7)
                {
                    TestUtil.ShowProblem(testMethodName, TestOutputMessage.ShouldReturnSingleNumer);
                }
            }
            catch (Exception exception)
            {
                TestUtil.ShowProblem(testMethodName, exception.ToString());
            }
        }
    }
}
