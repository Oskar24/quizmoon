using System.Threading.Tasks;

namespace QuizMoon.Client.Email;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}