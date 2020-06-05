using StructureMap;
using System;
using System.Diagnostics;

namespace FinalUnitTestBigExercise
{
    static class Program
    {
        static void Main()
        {
            var container = Container.For<DependencyRegistration>();
            var handler = container.GetInstance<Handler>();

            string threadUrl = "https://www.otosaigon.com/threads/camry-8x9x-and-more.4916883/";
            string outputPath = "result.txt";

            Console.WriteLine($"Getting a list of user and likes from {threadUrl}");

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = handler.GetUserLike(threadUrl);
            handler.WriteResult(result, outputPath);

            stopWatch.Stop();
            var timeStamp = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00} hours {1:00} minutes {2:00}.{3:00} seconds",
                timeStamp.Hours,
                timeStamp.Minutes,
                timeStamp.Seconds,
                timeStamp.Milliseconds / 10);

            Console.WriteLine($"The result output to {outputPath}!");
            Console.WriteLine($"It took {elapsedTime} to complete this task!");
            Console.ReadLine();
        }
    }
}
