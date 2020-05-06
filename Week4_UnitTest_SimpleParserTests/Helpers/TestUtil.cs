using System;

namespace Week4_UnitTest_SimpleParserTests.Helpers
{
    public static class TestUtil
    {
        public static void ShowProblem(string testMethodName, string testOutputMessage)
        {
            string message = $"{testMethodName}: {testOutputMessage}";

            Console.WriteLine(message);
        }
    }
}
