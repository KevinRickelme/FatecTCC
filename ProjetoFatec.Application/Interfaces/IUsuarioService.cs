using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Interfaces
{
    public interface IUsuarioService
    {
        void Add(UsuarioDTO cvm);
        bool PrimeiroAcesso(UsuarioDTO cvm);
        Task<UsuarioDTO?> GetUsuarioViewModel(string email);
        Task<Usuario> GetUsuario(string email);
        bool TemPerfilCriado(UsuarioDTO cvm);
    }
}
