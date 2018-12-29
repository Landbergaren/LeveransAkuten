using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers.HomeController
{
    public class HomeController : Controller
    {
        LoginService accService;
        public HomeController(LoginService accSer)
        {
            accService = accSer;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}