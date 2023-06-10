using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI3.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }

        public Perfil Perfil { get; set; }
        public int IdPerfil { get; set; }

        public string Descricao { get; set; }
        
        public Publicacao Publicacao { get; set; }
        public int IdPublicacao { get; set; }

        public DateTime DataComentario { get; set; }
    }
}
