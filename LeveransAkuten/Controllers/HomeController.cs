using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models;
using LeveransAkuten.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers.HomeController
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            accService.BuildIdentityDb();
            return View();
        }
    }
}