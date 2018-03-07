namespace ThoughtHaven.Messages.Emails
{
    public class EmailContent
    {
        public static EmailContent PlainText(string value) =>
            new EmailContent("text/plain", value);
        public static EmailContent Html(string value) =>
            new EmailContent("text/html", value);

        public string Type { get; }
        public string Value { get; }

        public EmailContent(string type, string value)
        {
            this.Type = Guard.NullOrWhiteSpace(nameof(type), type);
            this.Value = Guard.NullOrWhiteSpace(nameof(value), value);
        }
    }
}