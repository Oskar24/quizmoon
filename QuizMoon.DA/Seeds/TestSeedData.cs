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
            },
            new()
            {
                Id = 7,
                Question = "What is the difference between '==' and 'Equals' method in C#?",
                Answer = "'==' is used for checking reference equality, while 'Equals' is used for checking object equality based on overridden implementation."
            },
            new()
            {
                Id = 8,
                Question = "What is a lambda expression in C#?",
                Answer = "A concise way to represent anonymous methods using the '=>' syntax."
            },
            new()
            {
                Id = 9,
                Question = "Explain the 'using' statement in C#.",
                Answer = "It is used to define a scope at the end of which an object will be disposed of, helping in resource management."
            },
            new()
            {
                Id = 10,
                Question = "What is the purpose of the 'var' keyword in C#?",
                Answer = "'var' is used for implicitly declaring a local variable, letting the compiler infer its type."
            },
            new()
            {
                Id = 11,
                Question = "How do you implement an interface in C#?",
                Answer = "A class implements an interface by providing concrete implementations for all the methods declared in the interface."
            },
            new()
            {
                Id = 12,
                Question = "What is the difference between 'StringBuilder' and 'String' in C#?",
                Answer = "'StringBuilder' is mutable and can be modified, while 'String' is immutable and cannot be changed after creation."
            }
    });
    }
}