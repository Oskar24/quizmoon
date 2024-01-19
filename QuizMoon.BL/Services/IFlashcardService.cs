using QuizMoon.Models.DTO;

namespace QuizMoon.BL.Services;

public interface IFlashcardService
{
    Task<List<FlashcardDTO>> GetAllAvailableFlashcardsAsync();
}