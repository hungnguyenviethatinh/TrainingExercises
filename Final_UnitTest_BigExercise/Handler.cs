using System.Collections.Generic;

namespace FinalUnitTestBigExercise
{
    public interface Handler
    {
        IDictionary<string, int> GetUserLike(string threadUrl);
        void WriteResult(IDictionary<string, int> result, string outputPath);
    }
}
