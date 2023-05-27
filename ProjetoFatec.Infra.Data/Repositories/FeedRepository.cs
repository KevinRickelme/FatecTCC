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
    public class FeedRepository : IFeedRepository
    {
        private readonly ApplicationContext _context;
        public FeedRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Add(Feed feed)
        {
            _context.Feeds.Add(feed);
            _context.SaveChanges();
            return true;
        }

        public async Task<Feed> GetFeed(int IdPerfil)
        {
            Feed feed = _context.Feeds.Where(f => f.IdPerfil == IdPerfil).Include(p=>p.Perfil).FirstOrDefaultAsync().Result;
            feed.Perfil = _context.Perfis.Include("Amigos").FirstOrDefaultAsync(p => p.Id == IdPerfil).Result;
            feed.Perfil.Amigos = _context.Amigos.Where(a => a.IdPerfilSolicitado == IdPerfil || a.IdPerfilSolicitante == IdPerfil).ToList();
            List<int> IdAmigos = new();
            if(feed.Perfil.Amigos != null) {
                foreach (var id in feed.Perfil.Amigos)
                {
                    if (id.Status == Domain.Enums.StatusAmizadeEnum.Ativo)
                    {
                        IdAmigos.Add(id.IdPerfilSolicitante);
                        IdAmigos.Add(id.IdPerfilSolicitado);
                    }
                        
                        
                }
            }
            feed.Publicacoes = _context.Publicacoes.Where(p => p.IdPerfil == feed.IdPerfil || IdAmigos.Contains(p.IdPerfil)).Include(nameof(Perfil)).Include("Comentarios").OrderByDescending(p=>p.DataCriacao).ToList();

            return feed; 
        }
    }
}
