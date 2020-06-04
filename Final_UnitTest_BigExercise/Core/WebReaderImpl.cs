using FinalUnitTestBigExercise.Core.Interfaces;
using HtmlAgilityPack;

namespace FinalUnitTestBigExercise.Core
{
    public class WebReaderImpl : WebReader
    {
        public virtual HtmlNode Read(string url)
        {
                var website = new HtmlWeb();
                var htmlDocument = website.Load(url);

                return htmlDocument.DocumentNode;
        }
    }
}
