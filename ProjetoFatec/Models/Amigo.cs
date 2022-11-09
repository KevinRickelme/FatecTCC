using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Models
{
    public class Amigo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdPerfilSolicitado")]
        public Perfil PerfilSolicitado { get; set; } 
        [Required]
        [ForeignKey("IdPerfilSolicitante")]
        public Perfil PerfilSolicitante { get; set; }
        [Required]
        [Column("DataAmizade")]
        public DateTime DataAmizade { get; set; }
    }
}
