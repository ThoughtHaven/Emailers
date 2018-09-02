namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridOptions
    {
        public string ApiKey { get; }

        public SendGridOptions(string apiKey)
        {
            this.ApiKey = Guard.NullOrWhiteSpace(nameof(apiKey), apiKey);
        }
    }
}