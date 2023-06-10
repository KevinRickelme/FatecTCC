using Microsoft.AspNetCore.Http;
using SI3.Domain.Entities;

namespace SI3.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(Usuario cvm);
        bool PrimeiroAcesso(Usuario cvm);
        Task<Usuario?> GetUsuario(string email);
        bool TemPerfilCriado(Usuario cvm);
        void Update(Usuario usuario);
        Task<Usuario?> GetUsuarioAsNoTracking(string email);
    }
}
