using System.ComponentModel.DataAnnotations;

namespace QuizMoon.Client.Model;

public class EmailConfirmationRequest
{
    [Required]
    public string Email { get; set; } = string.Empty;
}