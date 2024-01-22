using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using QuizMoon.Client.Api;

namespace QuizMoon.Client.Data;

public class UserRepository : IUserRepository
{
    private readonly List<UserEntity> _users = [new UserEntity(3522, "roland", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=", "blue", "Admin")];

    public UserEntity? GetByUsernameAndPassword(string username, string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);

        return _users.SingleOrDefault(user => user.Name == username && user.Password == Convert.ToBase64String(hash));
    }
}