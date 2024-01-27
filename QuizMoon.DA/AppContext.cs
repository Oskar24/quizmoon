using Microsoft.EntityFrameworkCore;
using QuizMoon.DA.Seeds;
using QuizMoon.Models.Entities;

namespace QuizMoon.DA;

public class AppContext : DbContext
{
    public DbSet<Flashcard> Flashcards => Set<Flashcard>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=QuizMoon;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        TestSeedData.Seed(modelBuilder);
    }

}