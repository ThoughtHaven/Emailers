using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ThoughtHaven.Messages.Emails.SendGrid
{
    public class SendGridEmailService : IEmailService
    {
        protected SendGridClient Client { get; }

        public SendGridEmailService(string apiKey)
            : this(new SendGridClient(apiKey: Guard.NullOrWhiteSpace(nameof(apiKey), apiKey)))
        { }

        protected SendGridEmailService(SendGridClient client)
        {
            this.Client = Guard.Null(nameof(client), client);
        }

        public async Task Send(EmailMessage message)
        {
            Guard.Null(nameof(message), message);

            var email = new SendGridMessage();
            email.SetFrom(email: message.From.Email.Value, name: message.From.Name);
            email.SetSubject(message.Subject);

            foreach (var to in message.To)
            {
                email.AddTo(email: to.Email.Value, name: to.Name);
            }

            foreach (var content in message.Contents)
            {
                email.AddContent(content.Type, content.Value);
            }

            var response = await this.Client.SendEmailAsync(email).ConfigureAwait(false);

            if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
            {
                throw new Exception($"Failed to send email message via SendGrid. Status Code: {(int)response.StatusCode}. Message: {await response.Body.ReadAsStringAsync()}");
            }
        }
    }
}