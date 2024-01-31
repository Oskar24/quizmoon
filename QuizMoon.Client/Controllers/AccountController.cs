using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizMoon.Client.Model;
using QuizMoon.Models.Identity;
using System.Linq;
using System.Threading.Tasks;
using static QuizMoon.Client.Validators.CustomModelValidators;

namespace QuizMoon.Client.Controllers
{
    [Route("account/[action]")]
    public class AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager) : Controller
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
                ModelState.AddModelError("message_key", "This user does not exist.");
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

            if (!result.Succeeded)
            {
                if (result.Errors.Any(error => error.Description.ToLower().Contains("password")))
                {
                    ModelState.AddModelError("message_key", "Password must have at least 6 characters, one uppercase letter, one digit, and one special character.");
                }
                return View(model);
            }

            await signInManager.SignInAsync(newUser, false);
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