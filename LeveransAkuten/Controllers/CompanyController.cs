using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    public class CompanyController : Controller
    {
        //cars was here
        public IActionResult Index()
        {
            return View();
        }
    }
}