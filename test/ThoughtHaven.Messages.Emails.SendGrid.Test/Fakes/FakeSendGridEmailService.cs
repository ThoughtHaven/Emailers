using SendGrid;
using System.Net.Http;

namespace ThoughtHaven.Messages.Emails.SendGrid.Fakes
{
    public class FakeSendGridEmailService : SendGridEmailService
    {
        public FakeSendGridEmailService(FakeHttpMessageHandler handler)
            : base(new SendGridClient(new HttpClient(handler), apiKey: "fake")) { }
    }
}