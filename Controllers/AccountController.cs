
using BookingSystem.Models;
using BookingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;



namespace BookingSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager
            , SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;//assign
            signInManager = _signInManager;
        }


        //create Account
        [HttpGet]//Account/register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]//<form actio="Resgiter"
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userVm)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = userVm.UserName;
               
                userModel.PasswordHash = userVm.Password;
                IdentityResult result = await userManager.CreateAsync(userModel, userVm.Password);//save db cookie
                if (result.Succeeded)
                {
                    //create cookie "ID,name,roles"
                    await signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Room");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);//password
                    }
                }
            }
            //not valid
            // return View("Register", userVm);
            return View(userVm);//view =Register
        }
        //Check Acount Valid or not
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid == true)
            {
                //check cookie
                ApplicationUser userModel = await userManager.FindByNameAsync(userVM.UserNAme);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found == true)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", "Cairo"));
                        await signInManager.SignInWithClaimsAsync(userModel, userVM.RememberMe, claims);
                        // await  signInManager.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Name & password Not Correct");
            }
            return View(userVM);
        }

        //1 action
        public async Task<IActionResult> signout()
        {
            await signInManager.SignOutAsync();//
            return RedirectToAction("Login");
        }
        //---------------Add Admin
        //[Authorize(Roles = "Admin")]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin(RegisterViewModel userVm)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = userVm.UserName;
            
                userModel.PasswordHash = userVm.Password;//123 
                IdentityResult result = await userManager.CreateAsync(userModel, userVm.Password);//save db cookie
                if (result.Succeeded)
                {
                    //assign role to this account
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    //await userManager.AddClaimAsync
                    //create cookie "ID,name,roles"

                    //await signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);//password
                    }
                }
            }
            //not valid
            // return View("Register", userVm);
            return View(userVm);//view =Register
        }










    }
}
