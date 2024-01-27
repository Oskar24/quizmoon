using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizMoon.Models.Entities;

namespace QuizMoon.DA;

public class UserContext(DbContextOptions<UserContext> options) : IdentityDbContext<User>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=QuizMoon;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;");
    }
}