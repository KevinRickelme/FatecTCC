using SI3.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI3.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public PrivilegioEnum Privilegio { get; set; }
        public StatusUsuarioEnum Status { get; set; }
        public Perfil Perfil { get; set; }
        public int IdPerfil { get; set; }

    }
}
