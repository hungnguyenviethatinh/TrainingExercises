using HtmlAgilityPack;

namespace Final_UnitTest_BigExercise.Core.Interfaces
{
    public interface IWebReader
    {
        HtmlNode Read(string url);
    }
}
