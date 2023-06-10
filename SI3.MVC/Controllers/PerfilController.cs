using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SI3.Application.Interfaces;
using SI3.Application.DTOs;
using SI3.Domain.Entities;
using SI3.Utils;
using SI3.MVC.ViewModels;

namespace SI3.MVC.Controllers
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
            ViewBag.IdFotoPerfil = MeuPerfil.IdFotoPerfil;
            ViewData["PerfilUsuario"] = MeuPerfil;
            var xxx = MeuPerfil.Id;
            ViewBag.IdPerfil = xxx;
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
            var perfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = perfil;
            var listaPerfis = await _perfilService.GetPerfisByName(nome);
            return View(listaPerfis);
        }

        [Route("/Perfil/MeusAmigos")]
        [HttpGet]
        public async Task<IActionResult> MeusAmigos()
        {
            var perfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result.Perfil;
            ViewData["PerfilUsuario"] = perfil;
            var listaPerfis = await _perfilService.GetPerfisAmigosById(perfil.Id);
            return View(listaPerfis);
        }

        [Route("/Configuracoes")]
        [HttpGet]
        public async Task<IActionResult> Configuracoes(string? mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
                ViewBag.Sucesso = mensagem;
            var perfil = _usuarioService.GetUsuario(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result;
            ViewData["PerfilUsuario"] = perfil.Perfil;
            var perfilDTO = _perfilService.GetPerfilViewModel(perfil.Perfil.Id).Result;
            return View(perfilDTO);
        }

        [Route("/Configuracoes")]
        [HttpPost]
        public async Task<IActionResult> Configuracoes(PerfilDTO perfilDTO)
        {
            ViewData["PerfilUsuario"] = _usuarioService.GetUsuarioAsNoTracking(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result; 
            perfilDTO.Usuario = _usuarioService.GetUsuarioAsNoTracking(perfilDTO.Email).Result;
            _perfilService.Update(perfilDTO);
            return RedirectToAction("Configuracoes", new {@mensagem = "Alterações salvas com sucesso!"});
        }
        [Route("/AdicionarImagem")]
        [HttpPost]
        public async Task<IActionResult> AdicionarImagem([FromForm] ImagemPerfilViewModel ipvm)
        {
            var ImagemDoPerfil = Request.Form["imagemPerfil"];
            var usuario = _usuarioService.GetUsuarioAsNoTracking(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result;
            var perfil = _perfilService.GetPerfil(usuario.IdPerfil).Result;
            FotoPerfil fp = new FotoPerfil()
            {
                CaminhoFoto = SalvarImagem(ipvm.imagemPerfil, perfil.Id).Result,
                IdPerfil = perfil.Id,
                Perfil = perfil
            };
            int idFotoPerfil = await _perfilService.SalvarFotoPerfil(fp);
            perfil.IdFotoPerfil = idFotoPerfil;
            
            _perfilService.Update(perfil);
            //perfilDTO.Usuario = _usuarioService.GetUsuarioAsNoTracking(perfilDTO.Email).Result;

            return RedirectToAction(nameof(Index), new {@id = perfil.Id });
        }


        private async Task<string> SalvarImagem(IFormFile imagem, int idPerfil)
        {
            if (imagem != null)
            {
                var caminho = Path.Combine("wwwroot/imgs/perfil/" + idPerfil + "ImagemPerfil.png");
                using (FileStream stream = new FileStream(caminho, FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                    stream.Close();
                }
                return caminho;
            }
            else
            {
                return null;
            }
        }
    }
}
