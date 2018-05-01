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
            public class ServicesAndOptionsOverload
            {
                [Fact]
                public void NullServices_Throws()
                {
                    IServiceCollection services = null;

                    Assert.Throws<ArgumentNullException>("services", () =>
                    {
                        services.AddSendGrid(Options());
                    });
                }

                [Fact]
                public void NullOptions_Throws()
                {
                    Assert.Throws<ArgumentNullException>("options", () =>
                    {
                        new ServiceCollection().AddSendGrid(options: null);
                    });
                }

                [Fact]
                public void WhenCalled_AddsIEmailService()
                {
                    var services = new ServiceCollection();

                    services.AddSendGrid(Options());

                    var service = services.BuildServiceProvider()
                        .GetRequiredService<IEmailService>();

                    Assert.NotNull(service);
                    Assert.True(service is SendGridEmailService);
                }

                [Fact]
                public void WhenCalled_ReturnsServices()
                {
                    var services = new ServiceCollection();

                    var result = services.AddSendGrid(Options());

                    Assert.Equal(services, result);
                }
            }
        }

        private static SendGridOptions Options() => new SendGridOptions("key");
    }
}