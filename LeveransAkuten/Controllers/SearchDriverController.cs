using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeveransAkuten.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers
{
    public class SearchDriverController : Controller
    {
        private readonly SearchDriverService searchDriverService;

        public SearchDriverController(SearchDriverService searchDriverService)
        {
            this.searchDriverService = searchDriverService;
        }
        [Route("/Search/Driver")]
        public IActionResult Index()
        {
            searchDriverService.Index1();
            return View();
        }
    }
}