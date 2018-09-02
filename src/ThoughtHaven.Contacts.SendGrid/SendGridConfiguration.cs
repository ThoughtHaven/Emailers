namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridConfiguration
    {
        public string ApiKey { get; }

        public SendGridConfiguration(string apiKey)
        {
            this.ApiKey = Guard.NullOrWhiteSpace(nameof(apiKey), apiKey);
        }
    }
}