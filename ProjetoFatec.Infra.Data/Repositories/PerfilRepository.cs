using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Infra.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationContext _context;
        public PerfilRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Add(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            _context.SaveChanges();
            return true;
        }

        public async Task<Perfil?> GetPerfil(Usuario usuario)
        {
            return await _context.Perfis.FirstOrDefaultAsync(p => p.Usuario.Id == (usuario.Id));
        }
    }
}
