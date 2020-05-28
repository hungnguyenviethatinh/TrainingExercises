using StructureMap;
using System;

namespace Final_UnitTest_BigExercise
{
    static class Program
    {
        static void Main()
        {
            var container = Container.For<DependencyRegistration>();
            var handler = container.GetInstance<IHandler>();

            string threadUrl = "https://www.otosaigon.com/threads/camry-8x9x-and-more.4916883/";
            string outputPath = "result.txt";

            handler.RunAsync(threadUrl, outputPath).Wait();

            Console.WriteLine("The result output to result.txt");
            Console.ReadLine();
        }
    }
}
