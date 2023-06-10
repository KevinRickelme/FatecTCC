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
    public class ComentarioRepository : IComentarioRepository
    {
        public readonly ApplicationContext _context;
        public ComentarioRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int Add(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            IQueryable query = _context.Amigos.AsQueryable();
            IQueryable query2 = _context.Comentarios.AsQueryable();
            return _context.SaveChanges();
        }

        public ICollection<Comentario?> GetComentarios(int idPublicacao) 
        {
            return _context.Comentarios.Where(c => c.IdPublicacao == idPublicacao).ToList();
        }

        public int RemoveAll(int idPublicacao)
        {
            var comentarios = _context.Comentarios.Include("Perfil").Include(p=>p.Perfil.Amigos).Where(c => c.IdPublicacao == idPublicacao).ToList();

            foreach (var list in comentarios)
            {
                _context.Entry(list.Perfil).Reload();
                foreach (var am in list.Perfil.Amigos)
                {
                    _context.Entry(am).Reload();
                }
            }

            _context.Comentarios.RemoveRange(comentarios);
            return _context.SaveChanges();
        }
    }
}
