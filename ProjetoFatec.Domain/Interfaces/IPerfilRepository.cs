using Microsoft.AspNetCore.Http;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Domain.Interfaces
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
    }
}
