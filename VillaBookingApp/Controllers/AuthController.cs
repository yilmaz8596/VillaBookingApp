using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VillaBookingApp.Application.Common.Interfaces;
using VillaBookingApp.Domain.Entities;
using VillaBookingApp.Web.ViewModels;

namespace VillaBookingApp.Web.Controllers
{
    [Route("Auth")]
    public class AuthController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly RoleManager<IdentityRole> _role_manager = roleManager;

        [HttpGet("Login")]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginVM { RedirectUrl = returnUrl });
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if(user == null )
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginVM);
            }

            var check = await _signInManager.CheckPasswordSignInAsync(user, loginVM.Password, lockoutOnFailure: false);
            if (!check.Succeeded)
            {
                if (check.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "User account is locked out.");
                    return View(loginVM);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginVM);
            }

            // Sign in the already-loaded user to ensure the authentication cookie is created
            await _signInManager.SignInAsync(user, loginVM.RememberMe);

            TempData["success"] = "Login successful.";

            if (!string.IsNullOrEmpty(loginVM.RedirectUrl) && Url.IsLocalUrl(loginVM.RedirectUrl))
            {
                return LocalRedirect(loginVM.RedirectUrl);
            }
            return RedirectToAction("Index", "Villa");
        }

        [HttpPost("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword(string? returnUrl = null)
        {
            return View(new ForgotPasswordVM { RedirectUrl = returnUrl });
        }

        [HttpPost("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(ForgotPasswordVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            TempData["success"] = "If an account exists for that email, a password reset link has been sent.";
            return RedirectToAction("Login", new { returnUrl = vm.RedirectUrl });
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (!await _role_manager.RoleExistsAsync("User"))
                await _role_manager.CreateAsync(new IdentityRole("User"));

            var user = new AppUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                Name = vm.Name,
                PhoneNumber = vm.PhoneNumber,
            };

            var createResult = await _userManager.CreateAsync(user, vm.Password);
            if (!createResult.Succeeded)
            {
                foreach (var err in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }

                TempData["error"] = string.Join("\n", createResult.Errors.Select(e => e.Description));
                return View(vm);
            }

            await _userManager.AddToRoleAsync(user, "User");

            TempData["success"] = "Registration successful. Please log in.";
            return RedirectToAction("Login");
        }
    }
}
