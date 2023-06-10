using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI3.Domain.Entities
{
    public class Feed
    {
        public int Id { get; set; }
        public Perfil Perfil { get; set; }
        public int IdPerfil { get; set; }
        public List<Publicacao> Publicacoes { get; set; }

        public Feed()
        {

        }

        public Feed(int Id, Perfil Perfil, int IdPerfil, List<Publicacao> Publicacoes)
        {
            this.Id = Id;
            this.Perfil = Perfil;
            this.Publicacoes = Publicacoes;
            this.IdPerfil = IdPerfil;
        }

    }
}
