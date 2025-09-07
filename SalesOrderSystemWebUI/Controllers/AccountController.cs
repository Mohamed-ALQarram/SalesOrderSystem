using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SalesOrderSystemWebUI.Models;

namespace SalesOrderSystemWebUI.Controllers
{
    [AllowAnonymous]

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid && user is not null)
            {
                ApplicationUser SignedUser = new ApplicationUser { UserName = user.UserName,Email=user.Email, PhoneNumber=user.PhoneNumber };

                IdentityResult Result = await userManager.CreateAsync(SignedUser, user?.Password!);
                if (Result.Succeeded)
                {
                    if(!await roleManager.RoleExistsAsync(user!.Role))
                    {
                        IdentityRole role = new IdentityRole {Name=user.Role};
                        await roleManager.CreateAsync(role);
                    }
                    await userManager.AddToRoleAsync(SignedUser, user.Role);
                    await signInManager.SignInAsync(SignedUser, user.RememberMe);

                    if (user.Role == "Admin")
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("CreateOrder", "Order");
                }
                else
                    foreach (var item in Result.Errors)
                        ModelState.AddModelError("", item.Description);
            }
            return View("Register", user);
        }

        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("LogIn");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogIn(SignInViewModel user)
        {
            if (user is null)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var SignedUser = await userManager.FindByNameAsync(user.UserName);
                if (SignedUser is not null)
                {
                    if(await userManager.CheckPasswordAsync(SignedUser, user.PasswordHash))
                    {
                        await signInManager.SignInAsync(SignedUser, user.RememberMe);
                        var Roles =await userManager.GetRolesAsync(SignedUser);
                        if (Roles.Contains("Admin"))
                            return RedirectToAction("Index", "Home");
                        else 
                            return RedirectToAction("CreateOrder", "Order");
                    }
                }
            }
            ModelState.AddModelError("InvalidLogin", "Invalid Username or Password");
            return View("LogIn", user);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login");

            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(user);
                TempData["Success"] = "Your password has been changed successfully.";
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult AddRole()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityRole role, string userName)
        {

             var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                ViewBag.userName = userName;
                ViewBag.Role = role.Name;
                ModelState.AddModelError("", "Invalid UserName");
                return View();
            }
            if (!await roleManager.RoleExistsAsync(role.Name??""))
            {
                await roleManager.CreateAsync(role);
            }
            await userManager.AddToRoleAsync(user, role.Name!);
            return View("Index", "Home");
        }
    }
}