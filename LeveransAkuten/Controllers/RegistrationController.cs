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
        RegistrationServices regService;
        public RegistrationController(RegistrationServices regSer)
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
            if (!ModelState.IsValid)
                return View(nameof(Index), regVm);

            var createResult = await regService.CreateDriverAsync(regVm.Driver);

            if (!createResult.Succeeded)
            {
                //failed to create
                regVm.ErrorMsges = createResult.Errors.Select(p => p.Description).ToList();
                return View(nameof(Index), regVm);
            }

            return RedirectToAction("Index", "Driver");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(RegIndexVm regVm)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), regVm);

            var createResult = await regService.CreateCompanyAsync(regVm.Company);
            
            if (!createResult.Succeeded)
            {
                //failed to create
                regVm.ErrorMsges = createResult.Errors.Select(p => p.Description).ToList();
                return View(nameof(Index), regVm);
            }
            return RedirectToAction("Index", "Company");
        }
    }
}
