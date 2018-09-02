using SendGrid;
using System.Net.Http;

namespace ThoughtHaven.Contacts.SendGrid.Fakes
{
    public class FakeSendGridEmailService : SendGridEmailService
    {
        public SendGridClient Client { get; }

        public FakeSendGridEmailService(FakeHttpMessageHandler handler)
            : base(configuration: new SendGridConfiguration("fake"))
        {
            this.Client = new SendGridClient(new HttpClient(handler),
                apiKey: base.Configuration.ApiKey);
        }

        protected override SendGridClient CreateClient() => this.Client;
    }
}