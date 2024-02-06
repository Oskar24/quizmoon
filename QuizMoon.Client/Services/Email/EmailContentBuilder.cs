using System.Text.Encodings.Web;
using QuizMoon.Client.Services.Email.Interfaces;

namespace QuizMoon.Client.Services.Email;

public class EmailContentBuilder : IEmailContentBuilder
{
    public string GetEmailConfirmationContent(string callbackUrl)
    {
        return $"<b style=\"color: #222429\">Welcome to <span style=\"color: #33acdf\">Q</span>uiz<span style=\"color: #d4a32c\">m</span>oon!</b>" +
            $"<br>Click here to confirm your email:<br><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Confirm your email</a>";
    }
}