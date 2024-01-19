using QuizMoon.Models.Entities;

namespace QuizMoon.DA.Repositories;

public interface IFlashcardRepository
{
    Task<List<Flashcard>> GetAllAsync();
}