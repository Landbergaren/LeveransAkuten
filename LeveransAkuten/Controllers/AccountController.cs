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
        AccountService accountService;

        public AccountController(AccountService accSer)
        {
            accountService = accSer;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginVm loginVm)
        {
            var loginResult = await accountService.LoginUserAsync(loginVm);
            if (!ModelState.IsValid)
                return View(loginVm);
            if (!loginResult.Succeeded)
                return View(loginVm);

            return RedirectToAction(nameof(TestAuthLandingPage));
        }

        [Authorize]
        public IActionResult TestAuthLandingPage()
        {
            return Content("welcome Mr " + HttpContext.User.Identity.Name);
        }
    }
}