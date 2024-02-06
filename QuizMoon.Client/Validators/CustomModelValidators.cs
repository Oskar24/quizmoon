using System.Text.RegularExpressions;

namespace QuizMoon.Client.Validators
{
    public static class CustomModelValidators
    {
        public static bool IsValidEmail(string email)
        {
            Regex regex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }
    }
}
