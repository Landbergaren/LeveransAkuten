using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{


    [Authorize(Roles = "Company")]
    public class CompanyController : Controller
    {
        CompanyServices companyServices;
        UserManager<BudAkutenUsers> userManager;
        public CompanyController(CompanyServices compSer, UserManager<BudAkutenUsers> userMan)
        {
            companyServices = compSer;
            userManager = userMan;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            await companyServices.GetAdsNotStartedAsync(loggedInUser);
            return View();
        }
    }
}