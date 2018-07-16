using Microsoft.Extensions.DependencyInjection.Extensions;
using ThoughtHaven;
using ThoughtHaven.Contacts;
using ThoughtHaven.Contacts.SendGrid;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SendGridServiceCollectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services,
            SendGridOptions options)
        {
            Guard.Null(nameof(services), services);
            Guard.Null(nameof(options), options);

            var sendgrid = new SendGridEmailService(options);

            services.TryAddSingleton<IEmailService>(sendgrid);

            return services;
        }
    }
}