using FinalUnitTestBigExercise.Core;
using FinalUnitTestBigExercise.Core.Interfaces;
using StructureMap;

namespace FinalUnitTestBigExercise
{
    public class DependencyRegistration : Registry
    {
        public DependencyRegistration()
        {
            For<WebReader>().Use<WebReaderImpl>();
            For<HtmlParser>().Use<HtmlParserImpl>();
            For<ResultWriter>().Use<ResultWriterImpl>();
            For<Handler>().Use<HandlerImpl>();
        }
    }
}
