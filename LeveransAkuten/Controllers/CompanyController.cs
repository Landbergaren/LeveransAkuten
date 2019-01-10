using AutoMapper;
using LeveransAkuten.Models.ClaimTypes;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Company;
using LeveransAkuten.Models.ViewModels.Driver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Controllers
{


    [Authorize(Roles = Roles.Company)]
    public class CompanyController : Controller
    {
        private readonly AdsServices adService;
        private readonly IMapper mapper;
        private readonly DbFirstContext dbCtx;
        private readonly DriverService driverService;
        CompanyServices companyServices;
        UserManager<BudAkutenUsers> userManager;

        public CompanyController(CompanyServices compSer, DriverService driverSer, UserManager<BudAkutenUsers> userMan, AdsServices adSer, IMapper map, DbFirstContext dbCtx)
        {
            companyServices = compSer;
            userManager = userMan;
            mapper = map;
            this.dbCtx = dbCtx;
            adService = adSer;
            driverService = driverSer;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            var companyIndexVm = await companyServices.GetAdsNotStartedAsync(loggedInUser);

            return View(companyIndexVm);
        }

        [HttpGet]
        public IActionResult CreateAd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd(CompanyCreateAdVm adsVm)
        {
            if (!ModelState.IsValid)
                return View(adsVm);
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

        [HttpGet]
        [Route("company/Details/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            return View(await companyServices.GetCompanyByName(name));
        }

        [HttpGet, Route("Company/" + nameof(DriverDetails) + "/{driverId}")]
        public async Task<IActionResult> DriverDetails(int driverId)
        {
            var driverStringId = dbCtx.Driver.Where(d => d.Id == driverId).Select(d => d.AspNetUsersId).FirstOrDefault();

            var driver = await driverService.GetDriverDetailsByIdAsync(driverStringId.ToString());
            return View(driver);
        }

        [HttpGet]
        [Route("company/update/{name}")]
        public async Task<IActionResult> Update(string name)
        {
            var d = await companyServices.GetCompanyForUpdate(name);
            return View(d);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateVm company)
        {
            await companyServices.UpdateCompany(company);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImg(UploadImgVm image)
        {
            var u = User.Identity.Name;
            await companyServices.UploadImage(u, image.Img);
            return RedirectToAction(nameof(Details), new { name = u });
        }

        [HttpGet]
        public async Task<IActionResult> DriverSearch()
        {
            var drivers = await driverService.GetAllDrivers();
            return View(drivers);
        }

    }
}