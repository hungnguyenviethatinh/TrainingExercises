using System;

namespace Week4_UnitTest_C5_LogAnalyzer
{
    public sealed class ErrorInfo : IEquatable<ErrorInfo>
    {
        public int Severity { get; set; }
        public string Message { get; set; }

        public bool Equals(ErrorInfo other)
        {
            return (Severity == other.Severity && Message.Equals(other.Message, StringComparison.CurrentCultureIgnoreCase));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var errorInfoObj = obj as ErrorInfo;
            if (errorInfoObj == null)
            {
                return false;
            }

            return Equals(errorInfoObj);
        }

        public override int GetHashCode()
        {
            return Severity.GetHashCode();
        }
    }
}
