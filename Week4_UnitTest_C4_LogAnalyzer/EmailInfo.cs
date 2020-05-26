using System;

namespace Week4_UnitTest_C4_LogAnalyzer
{
    public sealed class EmailInfo : IEquatable<EmailInfo>
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public bool Equals(EmailInfo other)
        {
            return (To.Equals(other.To, StringComparison.CurrentCultureIgnoreCase)
                && Subject.Equals(other.Subject, StringComparison.CurrentCultureIgnoreCase)
                && Body.Equals(other.Body, StringComparison.CurrentCultureIgnoreCase));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            EmailInfo emailObj = obj as EmailInfo;
            if (emailObj == null)
            {
                return false;
            }

            return Equals(emailObj);
        }

        public override int GetHashCode()
        {
            return Body.GetHashCode();
        }
    }
}
