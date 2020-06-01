using System.Collections.Generic;

namespace Final_UnitTest_BigExercise
{
    public interface IHandler
    {
        IDictionary<string, int> GetUserLike(string threadUrl);
        void WriteResult(IDictionary<string, int> result, string outputPath);
    }
}
