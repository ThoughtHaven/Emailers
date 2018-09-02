using System;
using Xunit;

namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridConfigurationTests
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
                        new SendGridConfiguration(apiKey: null);
                    });
                }

                [Fact]
                public void EmptyApiKey_Throws()
                {
                    Assert.Throws<ArgumentException>("apiKey", () =>
                    {
                        new SendGridConfiguration(apiKey: "");
                    });
                }

                [Fact]
                public void WhiteSpaceApiKey_Throws()
                {
                    Assert.Throws<ArgumentException>("apiKey", () =>
                    {
                        new SendGridConfiguration(apiKey: " ");
                    });
                }

                [Fact]
                public void WhenCalled_SetsApiKey()
                {
                    var options = new SendGridConfiguration("key");

                    Assert.Equal("key", options.ApiKey);
                }
            }
        }
    }
}