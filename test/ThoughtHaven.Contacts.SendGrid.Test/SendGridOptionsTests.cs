using System;
using Xunit;

namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridOptionsTests
    {
        public class Constructor
        {
            public class ApiKeyOverload
            {
                [Fact]
                public void NullApiKey_Throws()
                {
                    Assert.Throws<ArgumentNullException>("apiKey", () =>
                    {
                        new SendGridOptions(apiKey: null!);
                    });
                }

                [Fact]
                public void EmptyApiKey_Throws()
                {
                    Assert.Throws<ArgumentException>("apiKey", () =>
                    {
                        new SendGridOptions(apiKey: "");
                    });
                }

                [Fact]
                public void WhiteSpaceApiKey_Throws()
                {
                    Assert.Throws<ArgumentException>("apiKey", () =>
                    {
                        new SendGridOptions(apiKey: " ");
                    });
                }

                [Fact]
                public void WhenCalled_SetsApiKey()
                {
                    var options = new SendGridOptions("key");

                    Assert.Equal("key", options.ApiKey);
                }
            }
        }
    }
}