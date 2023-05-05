using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Utils;

namespace ProjetoFatec.MVC.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilService _perfilService;
        private readonly IUsuarioService _usuarioService;
        public PerfilController(IPerfilService perfilService, IUsuarioService usuarioService)
        {
            _perfilService = perfilService;
            _usuarioService = usuarioService;
        }
        [Route("/Perfil/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var perfil = _perfilService.GetPerfil(id).Result;
            var MeuPerfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = MeuPerfil;
            ViewBag.IdPerfil = MeuPerfil.Id;
            ViewBag.MeuPerfil = ClaimUtils.GetClaimInfo(User, "emailaddress") == perfil.Usuario.Email ? true : false;
            Perfil VerPerfil = perfil;
            return View(VerPerfil);
        }
        [Route("/Perfil/PedidoAmizade")]
        public async Task<IActionResult> PedidoAmizade(int id)
        {
            var perfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = perfil;
            ViewBag.IdPerfil = perfil.Id;
            _perfilService.EnviarSolicitacao(perfil.Id, id);
            ViewBag.MeuPerfil = ClaimUtils.GetClaimInfo(User, "emailaddress") == perfil.Usuario.Email ? true : false;
            Perfil VerPerfil = perfil;
            return RedirectToAction("Index");
        }
    }
}
