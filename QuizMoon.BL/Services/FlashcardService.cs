using AutoMapper;
using QuizMoon.DA.Repositories;
using QuizMoon.Models.DTO;

namespace QuizMoon.BL.Services;

public class FlashcardService(IFlashcardRepository flashcardRepository, IMapper mapper) : IFlashcardService
{

    public async Task<List<FlashcardDTO>> GetAllAvailableFlashcardsAsync()
    {
        var allFlashcards = await flashcardRepository.GetAllAsync();
        return mapper.Map<List<FlashcardDTO>>(allFlashcards);

    }
}