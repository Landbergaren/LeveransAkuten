using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models.ViewModels.Registration;
using Microsoft.AspNetCore.Mvc;


namespace LeveransAkuten.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(RegIndexVm compRegVm)
        {
            return RedirectToAction("Index", "Driver");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany()
        {
            return RedirectToAction("Index", "Company");
        }
    }
}
