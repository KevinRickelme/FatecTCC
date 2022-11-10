using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Models
{
    [Table("Feed")]
    public class Feed
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }
        public List<Publicacao> Publicacao { get; set; }

    }
}
