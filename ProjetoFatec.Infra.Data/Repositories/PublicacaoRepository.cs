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
            _context.Publicacoes.Add(pb);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Publicacao?>> GetPublicacoes(Usuario usuario)
        {
            try
            {
                return await _context.Publicacoes.Where(p => p.Perfil.Usuario.Id == usuario.Id).Include("PublicacaoOriginal").OrderByDescending(p => p.DataCriacao).ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Publicacao GetPublicacao(int id)
        {
            return _context.Publicacoes.Where(p => p.Id == id).Include("Comentarios").FirstOrDefault();
        }

        public int RemovePublicacao(int idOriginal)
        {
            var listaPublicacaoRemover = _context.Publicacoes.Include("Perfil").Include(p => p.Perfil.Amigos).Where(p => p.Id == idOriginal).ToList();
            var lista2 = _context.Publicacoes.Include("Perfil").Include(p => p.Perfil.Amigos).Where(p => p.IdPublicacaoOriginal == idOriginal).ToList();
            foreach(var it in lista2)
                listaPublicacaoRemover.Add(it);
            foreach(var list in listaPublicacaoRemover)
            {
                _context.Entry(list.Perfil).Reload();
                foreach(var am in list.Perfil.Amigos)
                {
                    _context.Entry(am).Reload();
                }
            }
            _context.Publicacoes.RemoveRange(listaPublicacaoRemover);
            return _context.SaveChanges();
        }
    }
}
