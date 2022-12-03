using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;
using ProjetoFatec.Repositories;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;
using ProjetoFatec.Enums;
using System.Security.Claims;
using System.Net;

namespace ProjetoFatec.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private CookiesViewModel cookie;
        public UsuarioController(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepository = usuarioRepositorio;
            cookie = new CookiesViewModel();
        }

        public IActionResult Index()
        {
            if(HttpContext.User.Identities.FirstOrDefault().Claims.Count() > 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }


        public IActionResult Sair()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Cadastro()
        {
            CookiesViewModel cvm = new CookiesViewModel();
            cvm.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
            cvm.PrimeiroNome = cvm.Nome.Split()[0];
            cvm.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

            if (_usuarioRepository.PrimeiroAcesso(cvm)) { 
                _usuarioRepository.CadastrarUsuario(cvm);
                if ((_usuarioRepository.TemPerfilCriado(cvm)))
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    cookie = cvm;
                    ViewData["Claims"] = cvm;
                    return View();
                }
            }
            else
            {
                if (_usuarioRepository.TemPerfilCriado(cvm))
                {
                    return RedirectToAction("Index", "Home");
                }
                cookie = cvm;
                ViewData["Claims"] = cvm;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar()
        {
            try {
                CookiesViewModel cvm = new CookiesViewModel();
                cvm.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
                cvm.PrimeiroNome = cvm.Nome.Split()[0];
                cvm.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

                if(_usuarioRepository.PrimeiroAcesso(cvm))
                    _usuarioRepository.CadastrarUsuario(cvm);
                string EmailUsuario = ClaimUtils.GetClaimInfo(User, "emailaddress");
                if(!(_usuarioRepository.TemPerfilCriado(cvm)))
                    _usuarioRepository.CadastrarPerfilDeUsuario(Request.Form, EmailUsuario);
                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }



            
        }
    }
}
