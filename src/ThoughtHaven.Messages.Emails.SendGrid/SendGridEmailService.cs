using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ThoughtHaven.Messages.Emails.SendGrid
{
    public class SendGridEmailService : IEmailService
    {
        protected SendGridOptions Options { get; }

        public SendGridEmailService(SendGridOptions options)
        {
            this.Options = Guard.Null(nameof(options), options);
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

            var response = await this.CreateClient().SendEmailAsync(email)
                .ConfigureAwait(false);

            if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
            {
                throw new Exception($"Failed to send email message via SendGrid. Status Code: {(int)response.StatusCode}. Message: {await response.Body.ReadAsStringAsync()}");
            }
        }

        protected virtual SendGridClient CreateClient() =>
            new SendGridClient(this.Options.ApiKey);
    }
}