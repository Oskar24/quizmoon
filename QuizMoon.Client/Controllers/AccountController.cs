using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizMoon.Client.Model;
using QuizMoon.Models.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMoon.Client.Email;
using static QuizMoon.Client.Validators.CustomModelValidators;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;

namespace QuizMoon.Client.Controllers
{
    [Route("account/[action]")]
    public class AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IEmailSender emailSender) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
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
            if (!result.Succeeded)
            {
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("message_key", "Please ensure your email is confirmed .");
                }
                else
                {
                    ModelState.AddModelError("message_key", "This user does not exist or password is wrong.");
                }
                return View(model);
            }

            return Redirect("/");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
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
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, code = confirmationToken }, Request.Scheme);

                var emailMessage = $"<b style=\"color: #222429\">Welcome to <span style=\"color: #33acdf\">Q</span>uiz<span style=\"color: #d4a32c\">m</span>oon!</b>" +
                                   $"<br>Click here to confirm your email:<br><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Confirm your email</a>";
                await emailSender.SendEmailAsync("oskar.karbownik@live.com", "Confirm your email", emailMessage);
                
                return View("ConfirmationRequiredNotification");
            }

            if (!result.Errors.Any())
            {
                return View(model);
            }

            if (result.Errors.Any(error => error.Description.ToLower().Contains("password")))
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
        public async Task<IActionResult> ConfirmEmail(string? userId, string? code, string returnUrl)
        {
            if (userId == null || code == null)
            {
                return Redirect("/");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Redirect("/");
                //return RedirectToAction("Error", "Home");
            }
            Console.WriteLine("TEST!");
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View("ConfirmationSuccessNotification");
            }

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult GoBackToMainPage()
        {
            return Redirect("/");
        }

        [Authorize]
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
    }
}