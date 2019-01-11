using Microsoft.AspNetCore.Mvc;

namespace LeveransAkuten.Controllers.HomeController
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/errors")]
        public IActionResult Error()
        {
            return View();
        }
    }
}