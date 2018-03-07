using System.Threading.Tasks;

namespace ThoughtHaven.Messages.Emails
{
    public interface IEmailService
    {
        Task Send(EmailMessage message);
    }
}