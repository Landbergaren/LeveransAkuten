﻿using LeveransAkuten.Models;
using LeveransAkuten.Models.ClaimTypes;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeveransAkuten.Controllers
{
    public class AccountController : Controller
    {
        LoginServices accountService;
        UserManager<BudAkutenUsers> userManager;

        public AccountController(LoginServices accSer, UserManager<BudAkutenUsers> userMan)
        {
            accountService = accSer;
            userManager = userMan;
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
            if (!ModelState.IsValid)
                return View(loginVm);

            var loginResult = await accountService.LoginUserAsync(loginVm);
            if (!loginResult.Succeeded)
                return View(loginVm);

            //Successfull
            if (!string.IsNullOrEmpty(loginVm.ReturnUrl))
            {
                return Redirect(loginVm.ReturnUrl);
            }
            var roles = await accountService.GetRoleAsync(loginVm.Username);
            foreach (var role in roles)
            {
                if (role.Contains(Roles.Company))
                    return RedirectToAction("Index", "Company");
                else if (role.Contains(Roles.Driver))
                    return RedirectToAction("Index", "Driver");
            }
            //No roles available for user
            return View(loginVm);
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