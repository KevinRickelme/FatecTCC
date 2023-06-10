using SI3.Application.DTOs;
using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.Interfaces
{
    public interface IUsuarioService
    {
        void Add(UsuarioDTO cvm);
        void Update(UsuarioDTO usuario);
        bool PrimeiroAcesso(UsuarioDTO cvm);
        Task<UsuarioDTO?> GetUsuarioViewModel(string email);
        Task<Usuario> GetUsuario(string email);
        bool TemPerfilCriado(UsuarioDTO cvm);
        void AtualizarIdPerfil(string usuario, int IdPerfil);
        Task<Usuario> GetUsuarioAsNoTracking(string email);
    }
}
