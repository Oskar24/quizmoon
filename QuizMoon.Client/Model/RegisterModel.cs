using System.ComponentModel.DataAnnotations;

namespace QuizMoon.Client.Model
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "The Confirmation field is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match.")]
        public string PasswordConfirmation { get; set; } = string.Empty;
    }
}
