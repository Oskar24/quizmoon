using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizMoon.Client.Model;
using QuizMoon.Models.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuizMoon.Client.Validators.CustomModelValidators;
using Microsoft.AspNetCore.WebUtilities;
using QuizMoon.Client.Services.Email.Interfaces;

namespace QuizMoon.Client.Controllers
{
    [Route("account/[action]")]
    public class AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IEmailService emailService) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!IsValidEmail(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Please enter a valid email address.");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberLogin, false);
            if (result.Succeeded)
            {
                return Redirect("/");
            }

            ModelState.AddModelError("message_key", result.IsNotAllowed ? "Please ensure your email is confirmed." : "This user does not exist or password is wrong.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!IsValidEmail(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Please enter a valid email address.");
                return View(model);
            }

            var newUser = new User { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(newUser, model.Password);


            if (result.Succeeded)
            {
                var callbackUrl = await GetCallbackUrlByEmail(model.Email);
                await emailService.SendEmailConfirmation(model.Email, callbackUrl);
                return View("ConfirmationRequiredNotification");
            }

            if (!result.Errors.Any())
            {
                return View(model);
            }

            if (result.Errors.Any(error => error.Code.StartsWith("Password")))
            {
                ModelState.AddModelError("message_key", "Password must have at least 6 characters, one uppercase letter, one digit, and one special character.");
            }
            else
            {
                var errorMessage = string.Join(' ', result.Errors.Where(x => x.Code != "DuplicateUserName").Select(x => x.Description));
                ModelState.AddModelError("message_key", errorMessage);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string? userId, string? code)
        {
            if (userId == null || code == null)
            {
                return Redirect("/");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Redirect("/");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View("ConfirmationSuccessNotification");
            }

            if (result.Errors.Any(error => error.Code == "InvalidToken"))
            {
                return View("ConfirmationErrorNotification", new EmailConfirmationRequest());

            }
            return Redirect("/");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RenewEmailConfirmation(EmailConfirmationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View("ConfirmationErrorNotification", model);
            }

            if (!IsValidEmail(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Please enter a valid email address.");
                return View("ConfirmationErrorNotification", model);
            }

            var callbackUrl = await GetCallbackUrlByEmail(model.Email);

            await emailService.SendEmailConfirmation(model.Email, callbackUrl);
            return View("ConfirmationRequiredNotification");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GoBackToMainPage()
        {
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            var result = new JsonResult(User.Claims.Select(c => new { Type = c.Type, Value = c.Value }));
            return result;
        }

        private async Task<string> GetCallbackUrlByEmail(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                // TODO: Improve error handling
                throw new Exception($"User with such email: {userEmail} does not exist");
            }

            var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
            confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = confirmationToken }, Request.Scheme);

            if (callbackUrl == null)
            {
                // TODO: Improve error handling
                throw new Exception("Something went wrong with callback url");
            }

            return callbackUrl;
        }
    }
}