using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Core.Interfaces
{
    public interface IResultWriter
    {
        void WriteToFile(IDictionary<string, int> result, string path);
    }
}
