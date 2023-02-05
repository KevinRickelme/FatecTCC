using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.ViewModels;
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
        public UsuarioController(IUsuarioService usuarioService, IPerfilService perfilService)
        {
            _usuarioService = usuarioService;
            _perfilService = perfilService;
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
            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");



            if (_usuarioService.PrimeiroAcesso(usuario)) {
                _usuarioService.Add(usuario);
                if ((_usuarioService.TemPerfilCriado(usuario)))
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ViewBag.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
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
                ViewBag.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
                ViewBag.PrimeiroNome = (ClaimUtils.GetClaimInfo(User, "name")).Split()[0];
                ViewBag.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar()
        {
            try {
                UsuarioViewModel usuario = new UsuarioViewModel();
                usuario.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

                if(_usuarioService.PrimeiroAcesso(usuario))
                    _usuarioService.Add(usuario);
                string EmailUsuario = ClaimUtils.GetClaimInfo(User, "emailaddress");
                if(!(_usuarioService.TemPerfilCriado(usuario)))
                {
                    PerfilViewModel pf = CriarPerfil(Request.Form, EmailUsuario);
                    _perfilService.Add(pf);
                }
                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }



            
        }

        private PerfilViewModel CriarPerfil(IFormCollection formularioCadastro, string emailUsuario)
        {
            PerfilViewModel perfil = new PerfilViewModel()
            {
                Nome = formularioCadastro["PrimeiroNome"],
                Sobrenome = formularioCadastro["Sobrenome"],
                Telefone = formularioCadastro["DDD"] + formularioCadastro["Telefone"],
                Usuario = _usuarioService.GetUsuario(emailUsuario).Result,
                DataNascimento = Convert.ToDateTime(formularioCadastro["DataNascimento"]),
                Sexo = formularioCadastro["Sexo"] == "Feminino" ? SexoEnum.Feminino : SexoEnum.Masculino,
                NomeCurso = formularioCadastro["NomeCurso"],
                SemestreAtual = int.Parse(formularioCadastro["SemestreAtual"])
            };
            return perfil;
        }
    }
}
