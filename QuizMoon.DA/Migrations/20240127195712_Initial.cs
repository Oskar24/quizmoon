using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizMoon.DA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "class", "What keyword is used to define a new class in C#?" },
                    { 2, "int x = 10;", "How do you initialize an integer variable in C#?" },
                    { 3, "It is a mechanism that allows a class to inherit properties and behavior from another class.", "What does the term 'inheritance' mean in C#?" },
                    { 4, "ClassName myObject = new ClassName();", "How do you create a new instance of a class in C#?" },
                    { 5, "To display data on the console.", "What is the purpose of the Console.WriteLine method in C#?" },
                    { 6, "Using a try-catch block.", "How do you handle exceptions in C#?" },
                    { 7, "'==' is used for checking reference equality, while 'Equals' is used for checking object equality based on overridden implementation.", "What is the difference between '==' and 'Equals' method in C#?" },
                    { 8, "A concise way to represent anonymous methods using the '=>' syntax.", "What is a lambda expression in C#?" },
                    { 9, "It is used to define a scope at the end of which an object will be disposed of, helping in resource management.", "Explain the 'using' statement in C#." },
                    { 10, "'var' is used for implicitly declaring a local variable, letting the compiler infer its type.", "What is the purpose of the 'var' keyword in C#?" },
                    { 11, "A class implements an interface by providing concrete implementations for all the methods declared in the interface.", "How do you implement an interface in C#?" },
                    { 12, "'StringBuilder' is mutable and can be modified, while 'String' is immutable and cannot be changed after creation.", "What is the difference between 'StringBuilder' and 'String' in C#?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");
        }
    }
}
