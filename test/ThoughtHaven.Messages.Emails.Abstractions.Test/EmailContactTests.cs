using System;
using Xunit;

namespace ThoughtHaven.Messages.Emails
{
    public class EmailContactTests
    {
        public class Constructor
        {
            public class EmailAndNameOverload
            {
                [Fact]
                public void NullEmail_Throws()
                {
                    Assert.Throws<ArgumentNullException>("email", () =>
                    {
                        new EmailContact(email: null);
                    });
                }

                [Fact]
                public void EmptyName_Throws()
                {
                    Assert.Throws<ArgumentException>("name", () =>
                    {
                        new EmailContact("some@email.com", name: "");
                    });
                }

                [Fact]
                public void WhiteSpaceName_Throws()
                {
                    Assert.Throws<ArgumentException>("name", () =>
                    {
                        new EmailContact("some@email.com", name: " ");
                    });
                }

                [Fact]
                public void ValidEmail_SetsEmail()
                {
                    var email = new EmailContact("some@email.com");

                    Assert.Equal("some@email.com", email.Email);
                }

                [Fact]
                public void ValidName_SetsName()
                {
                    var email = new EmailContact("some@email.com", "Name");

                    Assert.Equal("Name", email.Name);
                }

                [Fact]
                public void NullName_SetsNameToNull()
                {
                    var email = new EmailContact("some@email.com", name: null);

                    Assert.Null(email.Name);
                }
            }
        }
    }
}