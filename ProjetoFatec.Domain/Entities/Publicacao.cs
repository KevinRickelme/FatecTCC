using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    [Table("Publicacao")]
    public class Publicacao
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdPerfil")]
        public Perfil? Perfil { get; set; }
        [Column("Legenda")]
        public string Legenda { get; set; }
        [Required]
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        public List<Comentario>? Comentario { get; set; }
        public string? CaminhoFoto { get; set; }
    }
}
