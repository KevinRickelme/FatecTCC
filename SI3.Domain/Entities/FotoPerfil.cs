using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI3.Domain.Entities
{
    public class FotoPerfil
    {
        public int Id { get; set; }

        public Perfil Perfil { get; set; }
        public int IdPerfil { get; set; }

        public string CaminhoFoto { get; set; }
    }
}