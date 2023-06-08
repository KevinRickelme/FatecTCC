using ProjetoFatec.Application.DTOs;
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
        Task<Perfil?> GetPerfil(UsuarioDTO usuario);
        Task<Perfil?> GetPerfil(int idPerfil);
        Task<PerfilDTO?> GetPerfilViewModel(int idPerfil);
        Task<PerfilDTO?> GetPerfilViewModel(UsuarioDTO usuario);
        bool Add(PerfilDTO perfil);
        bool Update(PerfilDTO perfil);
        bool Update(Perfil perfil);
        Task<Perfil?> GetPerfilWithoutNavigation(UsuarioDTO usuario);
        Task<List<PerfilDTO>> GetPerfisByName(string nome);
        Task<List<PerfilDTO>> GetPerfisAmigosById(int Id);
        Task<int> SalvarFotoPerfil(FotoPerfil fp);
    }
}
