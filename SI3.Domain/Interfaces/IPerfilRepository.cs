using Microsoft.AspNetCore.Http;
using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Domain.Interfaces
{
    public interface IPerfilRepository
    {
        Task<Perfil?> GetPerfil(Usuario usuario);
        Perfil? GetPerfil(int id);
        bool Add(Perfil perfil);
        bool Update(Perfil perfil);
        Task<Perfil?> GetPerfilWithoutNavigation(Usuario usuario);
        Task<List<Perfil>> GetPerfisByName(string nome);
        Task<List<Perfil>> GetPerfisByFullName(string[] arrayNome);
        Task<List<Perfil>> GetPerfisAmigosById(int Id);
        Task<int> SalvarFotoPerfil(FotoPerfil fp);
    }
}
