using System;
using Xunit;

namespace ThoughtHaven.Messages.Emails
{
    public class EmailMessageTests
    {
        public class Constructor
        {
            public class FromAndToAndSubjectAndContentOverload
            {
                [Fact]
                public void NullFrom_Throws()
                {
                    Assert.Throws<ArgumentNullException>("from", () =>
                    {
                        new EmailMessage(from: null, to: new EmailContact("to@email.com"),
                            subject: "subject", content: EmailContent.PlainText("value"));
                    });
                }

                [Fact]
                public void NullTo_Throws()
                {
                    Assert.Throws<ArgumentNullException>("to", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"), to: null,
                            subject: "subject", content: EmailContent.PlainText("value"));
                    });
                }

                [Fact]
                public void NullSubject_Throws()
                {
                    Assert.Throws<ArgumentNullException>("subject", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: null,
                            content: EmailContent.PlainText("value"));
                    });
                }

                [Fact]
                public void EmptySubject_Throws()
                {
                    Assert.Throws<ArgumentException>("subject", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: "",
                            content: EmailContent.PlainText("value"));
                    });
                }

                [Fact]
                public void WhiteSpaceSubject_Throws()
                {
                    Assert.Throws<ArgumentException>("subject", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: " ",
                            content: EmailContent.PlainText("value"));
                    });
                }

                [Fact]
                public void NullContent_Throws()
                {
                    Assert.Throws<ArgumentNullException>("content", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: "subject",
                            content: null);
                    });
                }

                [Fact]
                public void ValidFrom_SetsFrom()
                {
                    var from = new EmailContact("from@email.com");

                    var message = new EmailMessage(from: from,
                        to: new EmailContact("to@email.com"),
                        subject: "subject", content: EmailContent.PlainText("value"));

                    Assert.Equal(from, message.From);
                }

                [Fact]
                public void ValidTo_SetsTo()
                {
                    var to = new EmailContact("to@email.com");

                    var message = new EmailMessage(from: new EmailContact("from@email.com"),
                        to: to, subject: "subject", content: EmailContent.PlainText("value"));

                    Assert.Equal(to, message.To);
                }

                [Fact]
                public void ValidSubject_SetsSubject()
                {
                    var message = new EmailMessage(from: new EmailContact("from@email.com"),
                        to: new EmailContact("to@email.com"), subject: "subject",
                        content: EmailContent.PlainText("value"));

                    Assert.Equal("subject", message.Subject);
                }

                [Fact]
                public void ValidContent_SetsContent()
                {
                    var content = EmailContent.PlainText("value");

                    var message = new EmailMessage(from: new EmailContact("from@email.com"),
                        to: new EmailContact("to@email.com"), subject: "subject",
                        content: content);

                    Assert.Single(message.Contents);
                    Assert.Equal(content, message.Contents[0]);
                }
            }

            public class FromAndToAndSubjectAndContentsOverload
            {
                [Fact]
                public void NullFrom_Throws()
                {
                    Assert.Throws<ArgumentNullException>("from", () =>
                    {
                        new EmailMessage(from: null, to: new EmailContact("to@email.com"),
                            subject: "subject", contents: new EmailContent[]
                            { EmailContent.PlainText("value") });
                    });
                }

                [Fact]
                public void NullTo_Throws()
                {
                    Assert.Throws<ArgumentNullException>("to", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"), to: null,
                            subject: "subject", contents: new EmailContent[]
                            { EmailContent.PlainText("value") });
                    });
                }

                [Fact]
                public void NullSubject_Throws()
                {
                    Assert.Throws<ArgumentNullException>("subject", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: null,
                            contents: new EmailContent[] { EmailContent.PlainText("value") });
                    });
                }

                [Fact]
                public void EmptySubject_Throws()
                {
                    Assert.Throws<ArgumentException>("subject", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: "",
                            contents: new EmailContent[] { EmailContent.PlainText("value") });
                    });
                }

                [Fact]
                public void WhiteSpaceSubject_Throws()
                {
                    Assert.Throws<ArgumentException>("subject", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: " ",
                            contents: new EmailContent[] { EmailContent.PlainText("value") });
                    });
                }

                [Fact]
                public void NullContents_Throws()
                {
                    Assert.Throws<ArgumentNullException>("contents", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: "subject",
                            contents: null);
                    });
                }

                [Fact]
                public void ContentsWithNoItems_Throws()
                {
                    Assert.Throws<ArgumentException>("contents", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: "subject",
                            contents: new EmailContent[0]);
                    });
                }

                [Fact]
                public void ContentsWithNullItem_Throws()
                {
                    Assert.Throws<ArgumentException>("contents", () =>
                    {
                        new EmailMessage(from: new EmailContact("from@email.com"),
                            to: new EmailContact("to@email.com"), subject: "subject",
                            contents: new EmailContent[] { null });
                    });
                }

                [Fact]
                public void ValidFrom_SetsFrom()
                {
                    var from = new EmailContact("from@email.com");

                    var message = new EmailMessage(from: from,
                        to: new EmailContact("to@email.com"),
                        subject: "subject", contents: new EmailContent[]
                        { EmailContent.PlainText("value") });

                    Assert.Equal(from, message.From);
                }

                [Fact]
                public void ValidTo_SetsTo()
                {
                    var to = new EmailContact("to@email.com");

                    var message = new EmailMessage(from: new EmailContact("from@email.com"),
                        to: to, subject: "subject", contents: new EmailContent[]
                        { EmailContent.PlainText("value") });

                    Assert.Equal(to, message.To);
                }

                [Fact]
                public void ValidSubject_SetsSubject()
                {
                    var message = new EmailMessage(from: new EmailContact("from@email.com"),
                        to: new EmailContact("to@email.com"), subject: "subject",
                        contents: new EmailContent[] { EmailContent.PlainText("value") });

                    Assert.Equal("subject", message.Subject);
                }

                [Fact]
                public void ValidContent_SetsContent()
                {
                    var contents = new EmailContent[] { EmailContent.PlainText("value") };

                    var message = new EmailMessage(from: new EmailContact("from@email.com"),
                        to: new EmailContact("to@email.com"), subject: "subject",
                        contents: contents);

                    Assert.Equal(contents, message.Contents);
                }
            }
        }
    }
}