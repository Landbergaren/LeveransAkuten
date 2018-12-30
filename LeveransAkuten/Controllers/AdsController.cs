using AutoMapper;
using LeveransAkuten.Models;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdsServices adService;
        private readonly IMapper mapper;
        private readonly LoginServices account;
   
        public AdsController(AdsServices adService ,IMapper mapper,LoginServices account)
        {
            this.adService = adService;
            this.mapper = mapper;
            this.account = account;
           
        }
        [Route("/ads")]
        public IActionResult Index()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault().Value;
           
            var companyAds = adService.GetUserAds(userId);
            var companyAdsVm = mapper.Map<List<AdsVm>>(companyAds);
            return View(companyAdsVm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //await account.AddNewUserAsync();
           
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(AdsVm adsVm)
        {
            var id = HttpContext.User.Claims.FirstOrDefault().Value;
            await adService.AddAdsAsync(adsVm,id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var ad = adService.GetUserAd(id);
           
           var adToEdit =  mapper.Map<EditAdsVm>(ad);
            return View(adToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAdsVm ad)
        {
            await adService.EditAdsAsync(ad);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            
            await adService.RemoveAd(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var adDetails = adService.GetAdDetails(id);
            var adDetailsVm = mapper.Map<DetailsAdsVm>(adDetails);
            return View(adDetailsVm);
        }
    }
}