using AutoMapper;
using QuizMoon.Models.DTO;
using QuizMoon.Models.Entities;

namespace QuizMoon.Models.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        MapFlashcardModels();
    }

    private void MapFlashcardModels()
    {
        CreateMap<Flashcard, FlashcardDTO>();
    }
}