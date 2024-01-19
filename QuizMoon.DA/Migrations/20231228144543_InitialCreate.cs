using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizMoon.DA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "class", "What keyword is used to define a new class in C#?" },
                    { 2, "int x = 10;", "How do you initialize an integer variable in C#?" },
                    { 3, "It is a mechanism that allows a class to inherit properties and behavior from another class.", "What does the term 'inheritance' mean in C#?" },
                    { 4, "ClassName myObject = new ClassName();", "How do you create a new instance of a class in C#?" },
                    { 5, "To display data on the console.", "What is the purpose of the Console.WriteLine method in C#?" },
                    { 6, "Using a try-catch block.", "How do you handle exceptions in C#?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCards");
        }
    }
}
