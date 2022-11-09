using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }
        [Required]
        [Column("Privilegio")]
        public PrivilegioEnum Privilegio { get; set; }
        [Required]
        [Column("Status")]
        public StatusUsuarioEnum Status { get; set; }


    }
}
