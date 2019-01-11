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
        private readonly DriverService driverService;
        CompanyServices companyServices;
        UserManager<BudAkutenUsers> userManager;

        public CompanyController(CompanyServices compSer, DriverService driverSer, UserManager<BudAkutenUsers> userMan, AdsServices adSer)
        {
            companyServices = compSer;
            userManager = userMan;
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

        public async Task<IActionResult> EditAd(int id)
        {
            var adToEdit = await adService.GetEditAdsVm(id);            
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

            await adService.RemoveAdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AdDetails(int id)
        {
            var adDetailsVm = await adService.GetAdDetailsAsync(id);
            return View(adDetailsVm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string name)
        {
            name = User.Identity.Name;
            return View(await companyServices.GetCompanyByName(name));
        }

        [HttpGet, Route("Company/" + nameof(DriverDetails) + "/{driverId}")]
        public async Task<IActionResult> DriverDetails(int driverId)
        {
            var driverStringId = await driverService.GetUserIdWithDriverIdAsync(driverId);

            var driver = await driverService.GetDriverDetailsByIdAsync(driverStringId.ToString());
            return View(driver);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var name = User.Identity.Name;
            var d = await companyServices.GetCompanyForUpdate(name);
            return View(d);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateVm company)
        {
            if (!ModelState.IsValid)
                return View();

            var u = User.Identity.Name;
            await companyServices.UpdateCompanyAsync(company);
            return RedirectToAction(nameof(Details));

        }

        [HttpPost]
        public async Task<IActionResult> UploadImg(UploadImgVm image)
        {
            var userName = User.Identity.Name;

            if (!ModelState.IsValid)
                return Redirect(nameof(Details) + "/" + userName);

            await companyServices.UploadImage(userName, image.Img);
            return RedirectToAction(nameof(Details));
        }

        [HttpGet]
        public async Task<IActionResult> DriverSearch()
        {
            var drivers = await driverService.GetAllDrivers();
            return View(drivers);
        }

    }
}