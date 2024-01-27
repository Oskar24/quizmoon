using Microsoft.EntityFrameworkCore;
using QuizMoon.Models.Entities;

namespace QuizMoon.DA.Repositories;

public class FlashcardRepository(AppContext dbContext) : IFlashcardRepository
{
    public async Task<List<Flashcard>> GetAllAsync()
    {
        return await dbContext.Flashcards.ToListAsync();
    }

}