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
        bool Add(Perfil perfil);
    }
}
