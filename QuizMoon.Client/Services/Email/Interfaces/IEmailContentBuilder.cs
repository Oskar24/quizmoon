namespace QuizMoon.Client.Services.Email.Interfaces;

public interface IEmailContentBuilder
{
    public string GetEmailConfirmationContent(string callbackUrl);
}