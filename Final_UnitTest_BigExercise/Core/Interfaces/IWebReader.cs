using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Final_UnitTest_BigExercise.Core.Interfaces
{
    public interface IWebReader
    {
        HtmlNode Read(string url);
        Task<HtmlNode> ReadAsync(string url);
    }
}
