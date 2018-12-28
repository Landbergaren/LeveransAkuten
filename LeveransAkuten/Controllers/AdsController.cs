using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdsService adService;

        public AdsController(AdsService adService)
        {
            this.adService = adService;
        }
     
        public async Task<IActionResult> Index()
        {
            var CompanyAds = await adService.GetAllAdsAsync();
            return View(CompanyAds);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Create(AdsVm adsVm)
        {
            await adService.AddAdsAsync(adsVm);
            return RedirectToAction(nameof(Index));
        }



    }
}