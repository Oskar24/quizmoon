using Microsoft.Extensions.DependencyInjection;
using QuizMoon.BL.Services;
using QuizMoon.Client.Services.Email;
using QuizMoon.Client.Services.Email.Interfaces;
using QuizMoon.DA;
using QuizMoon.DA.Repositories;
using QuizMoon.Models.Mappings;

namespace QuizMoon.Client;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Client: Services 
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IEmailContentBuilder, EmailContentBuilder>();
        services.AddScoped<IEmailService, EmailService>();
        
        // Client: Other
        services.AddAutoMapper(typeof(MappingProfile));
        
        // BL: Services
        services.AddScoped<IFlashcardService, FlashcardService>();
        
        // DA: DB contexts
        services.AddDbContext<AppContext>();
        services.AddDbContext<UserContext>();

        // DA: Repositories
        services.AddScoped<IFlashcardRepository, FlashcardRepository>();
    }
}