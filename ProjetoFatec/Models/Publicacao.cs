using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Models
{
    [Table("Publicacao")]
    public class Publicacao
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }
        [Column("Legenda")]
        public string Legenda { get; set; }
        [Required]
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Required]
        [ForeignKey("IdFoto")]
        public Foto Foto { get; set; }


    }
}
