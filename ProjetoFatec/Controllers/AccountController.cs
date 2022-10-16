using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProjetoFatec.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [Route("login-microsoft")]
        public IActionResult MicrosoftLogin()
        {

            var prop = new AuthenticationProperties { RedirectUri = Url.Action("MicrosoftResponse") };



            return Challenge(prop, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        
        public async Task<IActionResult> MicrosoftResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return RedirectToAction("Index", "Home");
        }
    }
}
