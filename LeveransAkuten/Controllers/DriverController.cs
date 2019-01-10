using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeveransAkuten.Models.ClaimTypes;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Driver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    [Authorize(Roles = Roles.Driver)]
    public class DriverController : Controller
    {
      
        private readonly DriverService driverSer;
        private readonly UserManager<BudAkutenUsers> userMan;
        private readonly AdsServices adsServices;
        private readonly IMapper map;

        public DriverController(DriverService driverSer, UserManager<BudAkutenUsers> userMan,AdsServices adsServices, IMapper map)
        {
            
            this.driverSer = driverSer;
            this.userMan = userMan;
            this.adsServices = adsServices;
            this.map = map;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUser = await userMan.GetUserAsync(HttpContext.User);
            var driverIndexVm = await driverSer.GetAdsNotStartedAsync(loggedInUser);

            return View(driverIndexVm);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var name = User.Identity.Name;
            return View(await driverSer.GetDriverByUserName(name));
        }

        [HttpGet]
        public async Task<IActionResult> AdDetails(int id)
        {
            var adDetailsVm = await adsServices.GetAdDetailsAsync(id);
            return View(adDetailsVm);
        }

        [HttpPost]
        public async Task<IActionResult> TakeIt(int id)
        {
            var adDetails = await adsServices.GetAdDetailsAsync(id);
            if(!adDetails.Booked)
            {
                var ad = await adsServices.GetUserAdAsync(id);
                var driverUserId = HttpContext.User.Claims.FirstOrDefault().Value;
                var driverIdInt = driverSer.GetDriverId(driverUserId);
                
                ad.DriverId = driverIdInt;
                var adEdit = map.Map<EditAdsVm>(ad);
                await adsServices.EditAdsAsync(adEdit);              
            }
            return RedirectToAction(nameof(Index));
        }

      

        [HttpGet]
        public async Task<IActionResult> DisplayAds()
        {
            var ads = await driverSer.GetAllAdsAsync();
            var notBookedAds = ads.Where(x => x.DriverId == null).ToArray();
            var loggedInUser = await userMan.GetUserAsync(HttpContext.User);
            var driverId = driverSer.GetDriverId(loggedInUser.Id);
            AdSearchVm vm = new AdSearchVm
            {
                DriverId = driverId,
                Ads = notBookedAds
            };
            return View(vm);
        }
        
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var name = User.Identity.Name;
            var d = await driverSer.GetDriverForUpdate(name);
            return View(d);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DriverUpdateVm driver)
        {
            if (!ModelState.IsValid)
                return View();
            var u = User.Identity.Name;
            await driverSer.UpdateDriver(driver);
            return RedirectToAction(nameof(Details));
        }

        [HttpPost]
        public async Task<IActionResult> DisplayAds(AdsVm ad)
        {
            var filteredAds = await driverSer.FilterAds(ad);

            AdSearchVm vm = new AdSearchVm
            {
                Ads = filteredAds
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImg(UploadImgVm image)
        {
            var userName = User.Identity.Name;
            if (!ModelState.IsValid)
                return Redirect(nameof(Details) + "/" + userName);

            await driverSer.UploadImage(userName, image.Img);
            return RedirectToAction(nameof(Details));
        }
    }
}