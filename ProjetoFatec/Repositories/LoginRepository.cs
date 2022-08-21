using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Data;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;
using System.Security.Claims;

namespace ProjetoFatec.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationContext _context;
        public LoginRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ClaimsPrincipal> Login(LoginViewModel vm)
        {
            Usuario user = await _context.Logins.FirstOrDefaultAsync(u => u.UsuarioNome == vm.Usuario && u.UsuarioSenha == vm.Senha);

            if(user == null)
            {
                throw new Exception("Usuario/Senha Incorreto.");
            }

            List<Claim> claims = new List<Claim> 
            { 
                new Claim("Id", user.Id.ToString()),
                new Claim("Usuario", user.UsuarioNome),
                new Claim("Email", user.Email)
            };

            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            return principal;
        }
    }
}
