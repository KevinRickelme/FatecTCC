using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Infra.Data.Context;

namespace ProjetoFatec.Infra.Data.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository

    {
        private readonly ApplicationContext _context;
        public PublicacaoRepository(ApplicationContext context)
        {
            _context= context;
        }

        public bool Add(Publicacao pb)
        {
            _context.Add(pb);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Publicacao?>> GetPublicacoes(Usuario usuario)
        {
            try
            {
                return await _context.Publicacoes.Where(p => p.Perfil.Usuario.Id == usuario.Id).OrderByDescending(p => p.DataCriacao).ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
