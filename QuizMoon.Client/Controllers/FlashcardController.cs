using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizMoon.BL.Services;
using QuizMoon.Models.DTO;

namespace QuizMoon.Client.Controllers
{
    [Route("api/[controller]")]
    public class FlashcardController(IFlashcardService flashcardService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<FlashcardDTO>>> Index()
        {
            var allFlashcards = await flashcardService.GetAllAvailableFlashcardsAsync();
            return allFlashcards;
        }
    }
}
