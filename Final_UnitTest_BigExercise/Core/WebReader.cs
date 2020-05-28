using Final_UnitTest_BigExercise.Core.Interfaces;
using HtmlAgilityPack;
using System.Threading.Tasks;

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

        public virtual async Task<HtmlNode> ReadAsync(string url)
        {
            var website = new HtmlWeb();
            var htmlDocument = await website.LoadFromWebAsync(url);
            
            return htmlDocument.DocumentNode;
        }
    }
}
