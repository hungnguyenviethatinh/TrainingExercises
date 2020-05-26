namespace Week4_UnitTest_C5_LogAnalyzer
{
    public interface IWebService
    {
        void Write(ErrorInfo errorInfo);
        void Write(string message);
    }
}
