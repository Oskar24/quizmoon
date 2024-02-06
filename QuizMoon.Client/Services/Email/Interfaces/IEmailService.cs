using System.Threading.Tasks;

namespace QuizMoon.Client.Services.Email.Interfaces;

public interface IEmailService
{
    Task SendEmailConfirmation(string emailAddress, string callbackUrl);
}