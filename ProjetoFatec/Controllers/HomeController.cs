using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Models;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;
using System.Diagnostics;

namespace ProjetoFatec.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            CookiesViewModel cvm = new CookiesViewModel();
            cvm.Nome = ClaimUtils.GetClaimInfo(User, "name");
            cvm.Email = ClaimUtils.GetClaimInfo(User, "emailadress");
            ViewData["Claims"] = cvm;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}