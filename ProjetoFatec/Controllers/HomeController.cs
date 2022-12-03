using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;
using ProjetoFatec.Repositories;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;
using System.Diagnostics;

namespace ProjetoFatec.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepository usuarioRepositorio)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepositorio;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            CookiesViewModel cvm = new CookiesViewModel();
            cvm.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
            cvm.PrimeiroNome = cvm.Nome.Split()[0];
            cvm.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");
            ViewData["Claims"] = cvm;

            if (_usuarioRepository.PrimeiroAcesso(cvm))
            {
                return RedirectToAction("Cadastro", "Usuario");
            }
            else {
                if (!(_usuarioRepository.TemPerfilCriado(cvm)))
                {
                    return RedirectToAction("Cadastro", "Usuario");
                }
                    ViewData["PerfilUsuario"] = _usuarioRepository.GetPerfil(cvm);
                return View();
            }
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