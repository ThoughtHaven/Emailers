using System;
using Xunit;

namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridOptionsTests
    {
        public class ApiKeyProperty
        {
            public class SetOverload
            {
                [Fact]
                public void NullApiKey_Throws()
                {
                    var options = new SendGridOptions(apiKey: "key");

                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        options.ApiKey = null;
                    });
                }

                [Fact]
                public void EmptyApiKey_Throws()
                {
                    var options = new SendGridOptions(apiKey: "key");

                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        options.ApiKey = "";
                    });
                }

                [Fact]
                public void WhiteSpaceApiKey_Throws()
                {
                    var options = new SendGridOptions(apiKey: "key");

                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        options.ApiKey = " ";
                    });
                }

                [Fact]
                public void WhenCalled_SetsApiKey()
                {
                    var options = new SendGridOptions("key1");

                    options.ApiKey = "key2";

                    Assert.Equal("key2", options.ApiKey);
                }
            }
        }

        public class Constructor
        {
            public class ApiKeyOverload
            {
                [Fact]
                public void NullApiKey_Throws()
                {
                    Assert.Throws<ArgumentNullException>("apiKey", () =>
                    {
                        new SendGridOptions(apiKey: null);
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