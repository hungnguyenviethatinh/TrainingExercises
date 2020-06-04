using System.Collections.Generic;

namespace FinalUnitTestBigExercise.Core.Interfaces
{
    public interface ResultWriter
    {
        void WriteToFile(IDictionary<string, int> result, string path);
    }
}
