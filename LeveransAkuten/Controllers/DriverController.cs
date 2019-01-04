using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    [Authorize(Roles = "Driver")]
    public class DriverController : Controller
    {
      
        private readonly DriverService driverSer;
        private readonly UserManager<BudAkutenUsers> userMan;

        public DriverController(DriverService driverSer, UserManager<BudAkutenUsers> userMan)
        {
            
            this.driverSer = driverSer;
            this.userMan = userMan;
        }
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await userMan.GetUserAsync(HttpContext.User);
            var companyIndexVm = await driverSer.GetAdsNotStartedAsync(loggedInUser);

            return View(companyIndexVm);
        }

        [HttpGet]
        public IActionResult SearchAd ()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult>  DisplayAds ()
        {
            var ads = await driverSer.GetAllAds();
            AdSearchVm vm = new AdSearchVm
            {
                Ads = ads
            };
            return View(vm);
        }
    }
}