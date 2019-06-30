using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace ThoughtHaven.Contacts.SendGrid.DependencyInjection
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
                    IServiceCollection services = null!;

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
                        new ServiceCollection().AddSendGrid(options: null!);
                    });
                }

                [Fact]
                public void WhenCalled_AddsSendGridOptions()
                {
                    var services = new ServiceCollection();
                    var options = Options();

                    services.AddSendGrid(options);

                    var service = services.BuildServiceProvider()
                        .GetRequiredService<SendGridOptions>();

                    Assert.Equal(options, service);
                }

                [Fact]
                public void WhenCalled_AddsIEmailService()
                {
                    var services = new ServiceCollection();

                    services.AddSendGrid(Options());

                    var service = services.BuildServiceProvider()
                        .GetRequiredService<IEmailService>();

                    Assert.IsType<SendGridEmailService>(service);
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