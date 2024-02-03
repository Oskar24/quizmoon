using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuizMoon.Client.Email;

public class EmailSender : IEmailSender 
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        try
        {
            var fromAddress = new MailAddress("quizmooninfo@gmail.com", "Quizmoon");
            var toAddress = new MailAddress(email);

            using var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("quizmooninfo@gmail.com", "jlshswbjxbnesvzt");
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