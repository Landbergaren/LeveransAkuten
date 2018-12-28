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

        public IActionResult Login()
        {            
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login (LoginVm loginVm)
        //{

        //    return View();
        //}
    }
}