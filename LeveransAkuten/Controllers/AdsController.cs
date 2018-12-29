using AutoMapper;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeveransAkuten.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdsService adService;
        private readonly IMapper mapper;

        public AdsController(AdsService adService ,IMapper mapper)
        {
            this.adService = adService;
            this.mapper = mapper;
        }
        [Route("/ads")]
        public IActionResult Index()
        {
            var companyAds =  adService.GetAdsAsync();
            var companyAdsVm = mapper.Map<AdsVm>(companyAds);
            return View(companyAdsVm);
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