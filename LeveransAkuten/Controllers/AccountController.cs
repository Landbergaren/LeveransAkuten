using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task Login ()
        {

        }
    }
}