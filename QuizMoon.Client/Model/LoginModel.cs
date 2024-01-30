using System.ComponentModel.DataAnnotations;

namespace QuizMoon.Client.Model;

public class LoginModel
{
    [Required]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
    
    public bool RememberLogin { get; set; }
}