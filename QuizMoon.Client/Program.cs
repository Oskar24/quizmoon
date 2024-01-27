using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuizMoon.Client;
using QuizMoon.DA;
using QuizMoon.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Startup.ConfigureServices(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<UserContext>();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "__Host-spa";
//        options.Cookie.SameSite = SameSiteMode.Strict;
//        options.Events.OnRedirectToLogin = (context) =>
//        {
//            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//            return Task.CompletedTask;
//        };
//    });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("admin", policy => policy.RequireClaim("role", "Admin"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapControllers();

app.MapFallbackToFile("index.html"); ;
app.Run();
