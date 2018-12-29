using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Registration;
using Microsoft.AspNetCore.Mvc;


namespace LeveransAkuten.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationService regService;
        public RegistrationController(RegistrationService regSer)
        {
            regService = regSer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(RegIndexVm regVm)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(RegIndexVm regVm)
        {
            await regService.CreateCompanyAsync(regVm.Company);
            return RedirectToAction("Index", "Home");
        }
    }
}
