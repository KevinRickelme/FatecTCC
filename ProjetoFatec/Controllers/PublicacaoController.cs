using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;

namespace ProjetoFatec.Controllers
{
    [Authorize]
    public class PublicacaoController : Controller
    {
        private readonly ILogger<PublicacaoController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPublicacaoRepository _publicacaoRepository;


        public PublicacaoController(ILogger<PublicacaoController> logger, IUsuarioRepository usuarioRepositorio, IPublicacaoRepository publicacaoRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepositorio;
            _publicacaoRepository= publicacaoRepository;
        }


        public IActionResult PublicarPostagem()
        {
            try
            {
                CookiesViewModel cvm = new CookiesViewModel();
                cvm.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
                cvm.PrimeiroNome = cvm.Nome.Split()[0];
                cvm.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");
                var perfil = _usuarioRepository.GetPerfil(cvm);

                if (_publicacaoRepository.PostarPublicacao(Request.Form, perfil))
                    return RedirectToAction("Index", "Home");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
