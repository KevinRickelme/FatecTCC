using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Interfaces
{
    public interface IPerfilService
    {
        Task<Perfil?> GetPerfil(UsuarioViewModel usuario);
        Task<Perfil?> GetPerfil(int idPerfil);
        Task<PerfilViewModel?> GetPerfilViewModel(int idPerfil);
        Task<PerfilViewModel?> GetPerfilViewModel(UsuarioViewModel usuario);
        Task<bool> EnviarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado);
        bool Add(PerfilViewModel perfil);
        bool Update(PerfilViewModel perfil);
    }
}
