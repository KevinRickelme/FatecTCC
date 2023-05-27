using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Enums;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;

namespace ProjetoFatec.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPerfilService _perfilService;
        private readonly IFeedService _feedService;
        public UsuarioController(IUsuarioService usuarioService, IPerfilService perfilService, IFeedService feedService)
        {
            _usuarioService = usuarioService;
            _perfilService = perfilService;
            _feedService = feedService;
        }

        public IActionResult Index()
        {
            if(HttpContext.User.Identities.FirstOrDefault().Claims.Count() > 1)
            {
                return RedirectToAction("Index", "Home");

                //(DateTime.Now - DateTime.Now).Minutes

            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Sair()
        {
            HttpContext.SignOutAsync();
            ClaimUtils.RemoveClaims(User);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Cadastro()
        {
            UsuarioDTO usuario = new UsuarioDTO();
            usuario.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");



            if (_usuarioService.PrimeiroAcesso(usuario)) {
                _usuarioService.Add(usuario);
                if ((_usuarioService.TemPerfilCriado(usuario)))
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    var nome = (ClaimUtils.GetClaimInfo(User, "name"));
                    ViewBag.Nome = nome;
                    ViewBag.PrimeiroNome = (ClaimUtils.GetClaimInfo(User, "name")).Split()[0];
                    ViewBag.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");
                    return View();
                }
            }
            else
            {
                if (_usuarioService.TemPerfilCriado(usuario))
                {
                    return RedirectToAction("Index", "Home");
                }
                string nome = (ClaimUtils.GetClaimInfo(User, "name"));
                ViewBag.Nome = nome;
                ViewBag.PrimeiroNome = (ClaimUtils.GetClaimInfo(User, "name")).Split()[0];
                ViewBag.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar()
        {
            try {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

                if(_usuarioService.PrimeiroAcesso(usuario))
                    _usuarioService.Add(usuario);
                string EmailUsuario = ClaimUtils.GetClaimInfo(User, "emailaddress");
                if(!(_usuarioService.TemPerfilCriado(usuario)))
                {
                    PerfilDTO pf = CriarPerfil(Request.Form, EmailUsuario);
                    _perfilService.Add(pf);
                    
                    pf = _perfilService.GetPerfilViewModel(_usuarioService.GetUsuarioViewModel(EmailUsuario).Result).Result;
                    pf.Feed = SalvarFeed(_perfilService.GetPerfil(_usuarioService.GetUsuarioViewModel(EmailUsuario).Result).Result.Id).Result;
                    _usuarioService.AtualizarIdPerfil(usuario.Email, pf.Id);

                    //pf.Id = _perfilService.GetPerfil(_usuarioService.GetUsuarioViewModel(EmailUsuario).Result).Result.Id;

                }
                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }



            
        }

        private async Task<Feed> SalvarFeed(int IdPerfil)
        {
            FeedDTO feed = new FeedDTO()
            {
                IdPerfil = IdPerfil
            };
            _feedService.Add(feed);
            return await _feedService.GetFeed(IdPerfil);
        }

        private PerfilDTO CriarPerfil(IFormCollection formularioCadastro, string emailUsuario)
        {
            PerfilDTO perfil = new PerfilDTO()
            {
                Nome = formularioCadastro["PrimeiroNome"],
                Sobrenome = formularioCadastro["Sobrenome"],
                Telefone = formularioCadastro["DDD"] + formularioCadastro["Telefone"],
                Usuario = _usuarioService.GetUsuario(emailUsuario).Result,
                DataNascimento = Convert.ToDateTime(formularioCadastro["DataNascimento"]),
                Sexo = formularioCadastro["Sexo"] == "Feminino" ? SexoEnum.Feminino : SexoEnum.Masculino,
                NomeCurso = formularioCadastro["NomeCurso"],
                SemestreAtual = int.Parse(formularioCadastro["SemestreAtual"]),
                Biografia = "",
                Sobre = ""
            };
            return perfil;
        }
    }
}
