using System.Threading.Tasks;

namespace QuizMoon.Client.Services.Email.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}