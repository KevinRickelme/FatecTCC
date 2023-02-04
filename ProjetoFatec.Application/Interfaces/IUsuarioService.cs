using ProjetoFatec.Application.ViewModels;
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
        void Add(UsuarioViewModel cvm);
        bool PrimeiroAcesso(UsuarioViewModel cvm);
        Task<UsuarioViewModel?> GetUsuarioViewModel(string email);
        Task<Usuario> GetUsuario(string email);
        bool TemPerfilCriado(UsuarioViewModel cvm);
    }
}
