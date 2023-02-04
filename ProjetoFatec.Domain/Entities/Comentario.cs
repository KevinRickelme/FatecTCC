using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        public Perfil Perfil { get; set; }
        [Required]
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Required]
        [ForeignKey("IdPublicacao")]
        public Publicacao Publicacao { get; set; }
        [Required]
        [Column("DataComentario")]
        public DateTime DataComentario { get; set; }
    }
}
