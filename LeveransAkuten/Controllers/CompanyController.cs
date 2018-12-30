using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{


    [Authorize(Roles = "Company")]
    public class CompanyController : Controller
    {
        private readonly AdsServices adService;
        CompanyServices companyServices;
        UserManager<BudAkutenUsers> userManager;
        private readonly IMapper mapper;
        public CompanyController(CompanyServices compSer, UserManager<BudAkutenUsers> userMan, AdsServices adService, IMapper map)
        {
            companyServices = compSer;
            userManager = userMan;
            mapper = map;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            await companyServices.GetAdsNotStartedAsync(loggedInUser);
            return View();
        }

        public async Task<IActionResult> CreateAd(AdsVm adsVm)
        {
            var id = HttpContext.User.Claims.FirstOrDefault().Value;
            await adService.AddAdsAsync(adsVm, id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditAd(int id)
        {
            var ad = adService.GetUserAd(id);

            var adToEdit = mapper.Map<EditAdsVm>(ad);
            return View(adToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditAd(EditAdsVm ad)
        {
            await adService.EditAdsAsync(ad);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAd(int id)
        {

            await adService.RemoveAd(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AdDetails(int id)
        {
            var adDetails = adService.GetAdDetails(id);
            var adDetailsVm = mapper.Map<DetailsAdsVm>(adDetails);
            return View(adDetailsVm);
        }
    }
}