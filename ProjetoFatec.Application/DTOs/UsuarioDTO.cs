using ProjetoFatec.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.DTOs
{
    public class UsuarioDTO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public string Email { get; set; }
        public PrivilegioEnum Privilegio { get; set; }
        public StatusUsuarioEnum Status { get; set; }


    }
}
