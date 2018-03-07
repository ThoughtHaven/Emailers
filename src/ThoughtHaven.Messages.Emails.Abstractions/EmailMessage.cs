namespace ThoughtHaven.Messages.Emails
{
    public class EmailMessage
    {
        public EmailContact From { get; }
        public EmailContact To { get; }
        public string Subject { get; }
        public EmailContent[] Contents { get; }

        public EmailMessage(EmailContact from, EmailContact to, string subject,
            EmailContent content)
            : this(from: from, to: to, subject: subject, contents: new EmailContent[]
            {
                Guard.Null(nameof(content), content)
            })
        { }

        public EmailMessage(EmailContact from, EmailContact to, string subject,
            EmailContent[] contents)
        {
            Guard.Null(nameof(contents), contents);
            Guard.NoItems(nameof(contents), contents);
            Guard.NullItem(nameof(contents), contents);

            this.From = Guard.Null(nameof(from), from);
            this.To = Guard.Null(nameof(to), to);
            this.Subject = Guard.NullOrWhiteSpace(nameof(subject), subject);
            this.Contents = contents;
        }
    }
}