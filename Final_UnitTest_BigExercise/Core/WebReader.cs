using Final_UnitTest_BigExercise.Core.Interfaces;
using HtmlAgilityPack;

namespace Final_UnitTest_BigExercise.Core
{
    public class WebReader : IWebReader
    {
        public virtual HtmlNode Read(string url)
        {
                var website = new HtmlWeb();
                var htmlDocument = website.Load(url);

                return htmlDocument.DocumentNode;
        }
    }
}
