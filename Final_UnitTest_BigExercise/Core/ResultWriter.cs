using Final_UnitTest_BigExercise.Core.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Final_UnitTest_BigExercise.Core
{
    public class ResultWriter : IResultWriter
    {
        public void WriteToFile(IDictionary<string, int> result, string path)
        {
            using(StreamWriter writer = new StreamWriter(path, false))
            {
                foreach(var pair in result)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
