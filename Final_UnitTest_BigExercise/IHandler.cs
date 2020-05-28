using System.Threading.Tasks;

namespace Final_UnitTest_BigExercise
{
    public interface IHandler
    {
        void Run(string threadUrl, string outputPath);
        Task RunAsync(string threadUrl, string outputPath);
    }
}
