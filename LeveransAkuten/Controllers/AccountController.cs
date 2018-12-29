﻿using System;
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
        AccountService accountService;

        public AccountController(AccountService accSer)
        {
            accountService = accSer;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm loginVm, string returnUrl)
        {
            //Unsuccessfull
            var loginResult = await accountService.LoginUserAsync(loginVm);
            if (!ModelState.IsValid)
                return View(loginVm);
            if (!loginResult.Succeeded)
                return View(loginVm);

            //Successfull
            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction(nameof(TestAuth));
            else
                return Redirect(returnUrl);
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