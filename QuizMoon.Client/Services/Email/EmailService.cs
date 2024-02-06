using System.Threading.Tasks;
using QuizMoon.Client.Services.Email.Interfaces;

namespace QuizMoon.Client.Services.Email;

public class EmailService(IEmailContentBuilder emailContentBuilder, IEmailSender emailSender) : IEmailService
{
    public async Task SendEmailConfirmation(string emailAddress, string callbackUrl)
    {
        var emailSubject = "Confirm your email";
        var emailContent = emailContentBuilder.GetEmailConfirmationContent(callbackUrl);
        await emailSender.SendEmailAsync(emailAddress, emailSubject, emailContent);
    }
}