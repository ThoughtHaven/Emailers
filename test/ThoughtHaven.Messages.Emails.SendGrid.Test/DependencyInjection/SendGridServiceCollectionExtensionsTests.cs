using System;
using Xunit;
using ThoughtHaven.Messages.Emails;
using ThoughtHaven.Messages.Emails.SendGrid;

namespace Microsoft.Extensions.DependencyInjection
{
    public class SendGridServiceCollectionExtensionsTests
    {
        public class AddSendGridMethod
        {
            public class ServicesAndApiKeyOverload
            {
                [Fact]
                public void NullServices_Throws()
                {
                    IServiceCollection services = null;

                    Assert.Throws<ArgumentNullException>("services", () =>
                    {
                        services.AddSendGrid("key");
                    });
                }

                [Fact]
                public void NullApiKey_Throws()
                {
                    Assert.Throws<ArgumentNullException>("apiKey", () =>
                    {
                        new ServiceCollection().AddSendGrid(apiKey: null);
                    });
                }

                [Fact]
                public void EmptyApiKey_Throws()
                {
                    Assert.Throws<ArgumentException>("apiKey", () =>
                    {
                        new ServiceCollection().AddSendGrid(apiKey: "");
                    });
                }

                [Fact]
                public void WhiteSpaceApiKey_Throws()
                {
                    Assert.Throws<ArgumentException>("apiKey", () =>
                    {
                        new ServiceCollection().AddSendGrid(apiKey: " ");
                    });
                }

                [Fact]
                public void WhenCalled_AddsIEmailService()
                {
                    var services = new ServiceCollection();

                    services.AddSendGrid("key");

                    var service = services.BuildServiceProvider()
                        .GetRequiredService<IEmailService>();

                    Assert.NotNull(service);
                    Assert.True(service is SendGridEmailService);
                }

                [Fact]
                public void WhenCalled_ReturnsServices()
                {
                    var services = new ServiceCollection();

                    var result = services.AddSendGrid("key");

                    Assert.Equal(services, result);
                }
            }
        }
    }
}