namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridOptions
    {
        private string _apiKey;
        public string ApiKey
        {
            get => this._apiKey;
            set => this._apiKey = Guard.NullOrWhiteSpace(nameof(value), value);
        }

        public SendGridOptions(string apiKey)
        {
            this._apiKey = Guard.NullOrWhiteSpace(nameof(apiKey), apiKey);
        }
    }
}