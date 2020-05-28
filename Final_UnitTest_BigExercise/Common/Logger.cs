using Final_UnitTest_BigExercise.Common.Interfaces;
using System;

namespace Final_UnitTest_BigExercise.Common
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
