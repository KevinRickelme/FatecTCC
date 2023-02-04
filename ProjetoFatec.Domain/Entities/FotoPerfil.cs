using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    [Table("FotoPerfil")]
    public class FotoPerfil
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }
        [Required]
        [Column("CaminhoFoto")]
        public string CaminhoFoto { get; set; }
    }
}