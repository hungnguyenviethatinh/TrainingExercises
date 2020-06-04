using FinalUnitTestBigExercise.Core.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace FinalUnitTestBigExercise.Core
{
    public class ResultWriterImpl : ResultWriter
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
