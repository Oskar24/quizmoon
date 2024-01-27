using QuizMoon.Client.Data;

namespace QuizMoon.Client.Api;

public interface IUserRepository
{
    UserEntity? GetByUsernameAndPassword(string username, string password);
}