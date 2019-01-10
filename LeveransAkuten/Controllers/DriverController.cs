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
        [Route("driver/details/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            return View(await driverSer.GetDriverByUserName(name));
        }

        [HttpGet]
        public IActionResult AdDetails(int id)
        {
            var adDetails = adsServices.GetAdDetails(id);
            var adDetailsVm = map.Map<DetailsAdsVm>(adDetails);
            if (adDetails.DriverId != null)
            {
                adDetailsVm.Booked = true;
            }
            return View(adDetailsVm);
        }

        [HttpPost]
        public async Task<IActionResult> TakeIt(int id)
        {
            var adDetails = adsServices.GetAdDetails(id);
            if(adDetails.DriverId == null)
            {
                var ad = adsServices.GetUserAd(id);
                var driverId = HttpContext.User.Claims.FirstOrDefault().Value;
                var driverIdInt = driverSer.GetDriverId(driverId);
                
                ad.DriverId = driverIdInt;
                var adEdit = map.Map<EditAdsVm>(ad);
                await adsServices.EditAdsAsync(adEdit);
              
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult SearchAd()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAds()
        {
            var ads = await driverSer.GetAllAds();
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
        [Route("driver/update/{name}")]
        public async Task<IActionResult> Update(string name)
        {
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
            return RedirectToAction(nameof(Details), new { name = u });
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
            return RedirectToAction(nameof(Details), new { name = userName });
        }
    }
}