using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using QuizMoon.Client.Services.Email.Interfaces;

namespace QuizMoon.Client.Services.Email;

public class EmailSender : IEmailSender
{
    private const string FromAddress = "quizmooninfo@gmail.com";
    private const string FromName = "Quizmoon";
    private const string SmtpAppKey = "jlshswbjxbnesvzt";
    private const string SmtpHostAddress = "smtp.gmail.com";
    private const int SmtpHostPort = 587;

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        try
        {
            var fromAddress = new MailAddress(FromAddress, FromName);
            var toAddress = new MailAddress(email);

            using var smtp = new SmtpClient();
            smtp.Host = SmtpHostAddress;
            smtp.Port = SmtpHostPort;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(FromAddress, SmtpAppKey);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            using var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            await smtp.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email error: {ex.Message}");
        }
    }
}