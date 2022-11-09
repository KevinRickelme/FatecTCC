using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Data;
using ProjetoFatec.Enums;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;
using ProjetoFatec.ViewModels;
using System.Security.Claims;

namespace ProjetoFatec.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void CadastrarUsuario(CookiesViewModel cvm)
        {
            Usuario user = new Usuario()
            {
                Email = cvm.Email,
                Privilegio = PrivilegioEnum.Padrao,
                Status = StatusUsuarioEnum.Ativo
            };

            _context.Login.Add(user);
            _context.SaveChanges();
        }

        public bool PrimeiroAcesso(CookiesViewModel cvm)
        {
            bool result = _context.Login.Any(u => u.Email == cvm.Email);
            return !result;
        }
    }
}
