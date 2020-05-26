namespace Week4_UnitTest_C4_LogAnalyzer.Tests
{
    public class FakeEmailService : IEmailService
    {
        public EmailInfo Email { get; set; }

        public void SendEmail(EmailInfo email)
        {
            Email = email;
        }
    }
}
