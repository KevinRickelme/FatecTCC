using ProjetoFatec.Infra.Data.Context;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFatec.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Login.Add(usuario);
            _context.SaveChanges();
        }

        public async Task<Usuario?> GetUsuario(string email)
        {
            return await _context.Login.Include("Perfil").FirstOrDefaultAsync(u=> u.Email == email);
        }

        public bool PrimeiroAcesso(Usuario cvm)
        {
            bool result = _context.Login.Any(u => u.Email == cvm.Email);
             return !result;
        }

        public bool TemPerfilCriado(Usuario usuario)
        {
            try { 
                bool result = _context.Perfis.Any(p => p.Usuario.Id == usuario.Id);
                return result;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
    }
}
