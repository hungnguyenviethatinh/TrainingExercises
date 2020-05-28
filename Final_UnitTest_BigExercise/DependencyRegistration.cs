using Final_UnitTest_BigExercise.Common;
using Final_UnitTest_BigExercise.Common.Interfaces;
using Final_UnitTest_BigExercise.Core;
using Final_UnitTest_BigExercise.Core.Interfaces;
using StructureMap;

namespace Final_UnitTest_BigExercise
{
    public class DependencyRegistration : Registry
    {
        public DependencyRegistration()
        {
            For<ILogger>().Use<Logger>();
            For<IWebReader>().Use<WebReader>();
            For<IHtmlParser>().Use<HtmlParser>();
            For<IResultWriter>().Use<ResultWriter>();
            For<IHandler>().Use<Handler>();
        }
    }
}
