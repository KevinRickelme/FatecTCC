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
    public class CurtidaRepository : ICurtidaRepository
    {
        private readonly ApplicationContext _context;

        public CurtidaRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int Add(Curtida curtida)
        {
            if (_context.Curtidas.Any(c => c.IdPerfil == curtida.IdPerfil && c.IdPublicacao == curtida.IdPublicacao))
            {
                Delete(_context.Curtidas.Where(c=>c.IdPublicacao == curtida.IdPublicacao && c.IdPerfil == curtida.IdPerfil).First());
                return -1;
            }
            else
            {
                _context.Curtidas.Add(curtida);
                return _context.SaveChanges();
            }
        }

        public int Delete(Curtida curtida)
        {
            _context.Curtidas.Remove(curtida);
            return _context.SaveChanges();
        }
    }
}
