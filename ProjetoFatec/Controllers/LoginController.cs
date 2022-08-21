using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;

namespace ProjetoFatec.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepositorio)
        {
            _loginRepository = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginViewModel lvm)
        {
            try
            {
                var principal = await _loginRepository.Login(lvm);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties: new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddHours(8) });
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o login. {ex.Message}"; 
                return RedirectToAction("Index");
            }
        }
    }
}
