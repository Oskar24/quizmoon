using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizMoon.Client.Api;
using QuizMoon.Client.Model;
using QuizMoon.Models.Identity;
using System.Linq;
using System.Threading.Tasks;
using static QuizMoon.Client.Validators.CustomModelValidators;

namespace QuizMoon.Client.Controllers
{
    [Route("account/[action]")]
    public class AccountController(
        IUserRepository userRepository,
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

            if (!IsValidEmail(model.Username))
            {
                ModelState.AddModelError(nameof(model.Username), "Please enter a valid email address.");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, false);
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
            var newUser = new User() { UserName = model.Email, Email = model.Email };

            var result = await userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return View(model);
            }

            await signInManager.SignInAsync(newUser, false);
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