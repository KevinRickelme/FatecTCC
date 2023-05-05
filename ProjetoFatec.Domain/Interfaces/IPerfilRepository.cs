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
        Task<Perfil?> GetPerfil(int id);
        bool EnviarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado);
        bool Add(Perfil perfil);
        bool Update(Perfil perfil);
    }
}
