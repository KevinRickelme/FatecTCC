using ProjetoFatec.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    public class Amigo
    {
        public int Id { get; set; }
        public Perfil PerfilSolicitante { get; set; }
        public int IdPerfilSolicitante { get; set; }
        public int IdPerfilSolicitado { get; set; }
        public StatusAmizadeEnum Status { get; set; } = StatusAmizadeEnum.Pendente;
        public DateTime DataAmizade { get; set; }
    }
}
