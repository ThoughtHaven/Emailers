using Microsoft.Extensions.DependencyInjection.Extensions;
using ThoughtHaven;
using ThoughtHaven.Messages.Emails;
using ThoughtHaven.Messages.Emails.SendGrid;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SendGridServiceCollectionExtensions
    {
        public static IServiceCollection AddSendGrid(this IServiceCollection services,
            string apiKey)
        {
            Guard.Null(nameof(services), services);
            Guard.NullOrWhiteSpace(nameof(apiKey), apiKey);

            var sendgrid = new SendGridEmailService(apiKey);

            services.TryAddSingleton<IEmailService>(sendgrid);

            return services;
        }
    }
}