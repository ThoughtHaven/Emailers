using SendGrid;
using System.Net.Http;

namespace ThoughtHaven.Messages.Emails.SendGrid.Fakes
{
    public class FakeSendGridEmailService : SendGridEmailService
    {
        public SendGridClient Client { get; }

        public FakeSendGridEmailService(FakeHttpMessageHandler handler)
            : base(options: new SendGridOptions("fake"))
        {
            this.Client = new SendGridClient(new HttpClient(handler),
                apiKey: base.Options.ApiKey);
        }

        protected override SendGridClient CreateClient() => this.Client;
    }
}