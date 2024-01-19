using Microsoft.EntityFrameworkCore;
using QuizMoon.Models.Entities;

namespace QuizMoon.DA.Seeds;

public class TestSeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flashcard>().HasData(new List<Flashcard>
        {
            new()
            {
                Id = 1,
                Question = "What keyword is used to define a new class in C#?",
                Answer = "class"
            },
            new()
            {
                Id = 2,
                Question = "How do you initialize an integer variable in C#?",
                Answer = "int x = 10;"
            },
            new()
            {
                Id = 3,
                Question = "What does the term 'inheritance' mean in C#?",
                Answer = "It is a mechanism that allows a class to inherit properties and behavior from another class."
            },
            new()
            {
                Id = 4,
                Question = "How do you create a new instance of a class in C#?",
                Answer = "ClassName myObject = new ClassName();"
            },
            new()
            {
                Id = 5,
                Question = "What is the purpose of the Console.WriteLine method in C#?",
                Answer = "To display data on the console."
            },
            new()
            {
                Id = 6,
                Question = "How do you handle exceptions in C#?",
                Answer = "Using a try-catch block."
            }
        });
    }
}