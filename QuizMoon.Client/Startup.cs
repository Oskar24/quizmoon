using Microsoft.Extensions.DependencyInjection;
using QuizMoon.BL.Services;
using QuizMoon.DA;
using QuizMoon.DA.Repositories;
using QuizMoon.Models.Mappings;

namespace QuizMoon.Client;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddAutoMapper(typeof(MappingProfile));
     
        services.AddScoped<IFlashcardRepository, FlashcardRepository>();
        services.AddScoped<IFlashcardService, FlashcardService>();
    }
}