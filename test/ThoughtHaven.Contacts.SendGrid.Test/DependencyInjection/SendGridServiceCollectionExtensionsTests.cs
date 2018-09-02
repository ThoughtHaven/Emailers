using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace ThoughtHaven.Contacts.SendGrid.DependencyInjection
{
    public class SendGridServiceCollectionExtensionsTests
    {
        public class AddSendGridMethod
        {
            public class ServicesAndConfigurationOverload
            {
                [Fact]
                public void NullServices_Throws()
                {
                    IServiceCollection services = null;

                    Assert.Throws<ArgumentNullException>("services", () =>
                    {
                        services.AddSendGrid(Configuration());
                    });
                }

                [Fact]
                public void NullConfiguration_Throws()
                {
                    Assert.Throws<ArgumentNullException>("configuration", () =>
                    {
                        new ServiceCollection().AddSendGrid(configuration: null);
                    });
                }

                [Fact]
                public void WhenCalled_AddsSendGridConfiguration()
                {
                    var services = new ServiceCollection();
                    var configuration = Configuration();

                    services.AddSendGrid(configuration);

                    var service = services.BuildServiceProvider()
                        .GetRequiredService<SendGridConfiguration>();

                    Assert.Equal(configuration, service);
                }

                [Fact]
                public void WhenCalled_AddsIEmailService()
                {
                    var services = new ServiceCollection();

                    services.AddSendGrid(Configuration());

                    var service = services.BuildServiceProvider()
                        .GetRequiredService<IEmailService>();

                    Assert.IsType<SendGridEmailService>(service);
                }

                [Fact]
                public void WhenCalled_ReturnsServices()
                {
                    var services = new ServiceCollection();

                    var result = services.AddSendGrid(Configuration());

                    Assert.Equal(services, result);
                }
            }
        }

        private static SendGridConfiguration Configuration() =>
            new SendGridConfiguration("key");
    }
}