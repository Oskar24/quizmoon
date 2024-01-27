namespace QuizMoon.Client.Model
{
    public class RegisterModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirmation { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
