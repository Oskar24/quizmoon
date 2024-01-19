using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMoon.Models.Entities;

public class Flashcard
{
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
}