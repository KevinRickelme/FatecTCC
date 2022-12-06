using ProjetoFatec.Data;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;

namespace ProjetoFatec.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository

    {
        private readonly ApplicationContext _context;
        public PublicacaoRepository(ApplicationContext context)
        {
            _context= context;
        }
        public bool PostarPublicacao(IFormCollection formularioPublicacao, Perfil perfil)
        {
            Publicacao pb = new Publicacao();
            pb.DataCriacao = DateTime.Now;
            pb.Legenda = formularioPublicacao["textoPublicacao"];
            pb.Perfil = perfil;

            try { 
                _context.Publicacoes.Add(pb);
                 _context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }





        }
    }
}
