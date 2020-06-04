using HtmlAgilityPack;

namespace FinalUnitTestBigExercise.Core.Interfaces
{
    public interface WebReader
    {
        HtmlNode Read(string url);
    }
}
