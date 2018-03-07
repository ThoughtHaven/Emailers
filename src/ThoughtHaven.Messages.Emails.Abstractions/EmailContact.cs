namespace ThoughtHaven.Messages.Emails
{
    public class EmailContact
    {
        public EmailAddress Email { get; }
        public string Name { get; }

        public EmailContact(EmailAddress email, string name = null)
        {
            this.Email = Guard.Null(nameof(email), email);

            if (name != null) { Guard.NullOrWhiteSpace(nameof(name), name); }

            this.Name = name;
        }
    }
}