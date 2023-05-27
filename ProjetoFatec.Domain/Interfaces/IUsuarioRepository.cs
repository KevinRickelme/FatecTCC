using Microsoft.AspNetCore.Http;
using ProjetoFatec.Domain.Entities;

namespace ProjetoFatec.Domain.Interfaces
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
