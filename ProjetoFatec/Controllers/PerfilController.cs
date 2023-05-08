using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Utils;

namespace ProjetoFatec.MVC.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilService _perfilService;
        private readonly IUsuarioService _usuarioService;
        private readonly IAmigoService _amigoService;
        public PerfilController(IPerfilService perfilService, IUsuarioService usuarioService, IAmigoService amigoService)
        {
            _perfilService = perfilService;
            _usuarioService = usuarioService;
            _amigoService = amigoService;
        }
        [Route("/Perfil/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var perfil = _perfilService.GetPerfilViewModel(id).Result;
            var MeuPerfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = MeuPerfil;
            ViewBag.IdPerfil = MeuPerfil.Id;
            ViewBag.MeuPerfil = ClaimUtils.GetClaimInfo(User, "emailaddress") == perfil.Usuario.Email ? true : false;
            
            return View(perfil);
        }
        [Route("/Perfil/PedidoAmizade")]
        public async Task<IActionResult> PedidoAmizade(int id)
        {
            var perfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = perfil;
            ViewBag.IdPerfil = perfil.Id;
            _amigoService.EnviarSolicitacao(perfil.Id, id);
            ViewBag.MeuPerfil = ClaimUtils.GetClaimInfo(User, "emailaddress") == perfil.Usuario.Email ? true : false;
            Perfil VerPerfil = perfil;
            return RedirectToAction("Index", new { @id = id });
        }

        [Route("/Perfil/DesfazerPedidoAmizade")]
        public async Task<IActionResult> DesfazerPedidoAmizade(int id)
        {
            var perfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = perfil;
            ViewBag.IdPerfil = perfil.Id;
            _amigoService.RecusarSolicitacao(perfil.Id, id);
            ViewBag.MeuPerfil = ClaimUtils.GetClaimInfo(User, "emailaddress") == perfil.Usuario.Email ? true : false;
            Perfil VerPerfil = perfil;
            return RedirectToAction("Index", new { @id = id });
        }

        [Route("/Perfil/RespostaPedidoAmizade")]
        [HttpPost]
        public async Task<IActionResult> RespostaPedidoAmizade(int idSolicitante, int idSolicitado, int acao)
        {
            bool sucesso = acao == 1 ? _amigoService.AceitarSolicitacao(idSolicitante, idSolicitado) : _amigoService.RecusarSolicitacao(idSolicitante, idSolicitado);

            return RedirectToAction("Index", "Home");
        }

        [Route("/Perfil/{nome}")]
        [HttpPost]
        public async Task<IActionResult> ResultadoPesquisa(string nome)
        {
            ViewData["PerfilUsuario"] = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            var listaPerfis = await _perfilService.GetPerfisByName(nome);
            return View(listaPerfis);
        }

    }
}
