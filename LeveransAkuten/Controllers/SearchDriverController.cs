using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeveransAkuten.Models.Services;
using LeveransAkuten.Models.ViewModels.SearchDriver;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    public class SearchDriverController : Controller
    {
        private readonly SearchDriverServices searchDriverService;
        private readonly IMapper map;

        public SearchDriverController(SearchDriverServices searchDriverService, IMapper map)
        {
            this.searchDriverService = searchDriverService;
            this.map = map;
        }
        [Route("/Search/Driver")]
        public IActionResult Index()
        {
            var DriverList = searchDriverService.GetDriverList();
            var DriverListVm = map.Map<List<List<SearchDriverVm>>>(DriverList);
            return View(DriverList);
        }
    }
}