using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models;
using LeveransAkuten.Models.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    public class AccountController : Controller
    {
        LoginServices accountService;

        public AccountController(LoginServices accSer)
        {
            accountService = accSer;
        }

        public async Task<IActionResult> Login(string ReturnUrl)
        {
            await accountService.IfNotExistCreateRolesAsync();
            return View(new LoginVm { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            
            //Unsuccessfull
            var loginResult = await accountService.LoginUserAsync(loginVm);
            if (!ModelState.IsValid)
                return View(loginVm);
            if (!loginResult.Succeeded)
                return View(loginVm);

            //Successfull
            if (string.IsNullOrEmpty(loginVm.ReturnUrl))
                return RedirectToAction("Index", "home");
            else
                return Redirect(loginVm.ReturnUrl);
        }

        [Authorize]
        public IActionResult TestAuth()
        {
            return Content("welcome Mr " + HttpContext.User.Identity.Name);
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}