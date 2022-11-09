using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;
using ProjetoFatec.Repositories;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;

namespace ProjetoFatec.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepository = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Método responsável por fazer a autenticação do usuário via Microsoft OAuth 2.0
        [Authorize]
        public IActionResult Login()
        {
            CookiesViewModel cvm = new CookiesViewModel();
            cvm.Nome = ClaimUtils.GetClaimInfo(User, "name");
            cvm.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

            if (_usuarioRepository.PrimeiroAcesso(cvm))
                _usuarioRepository.CadastrarUsuario(cvm);
            return View("Index","Home");
        }

        public IActionResult Sair()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
