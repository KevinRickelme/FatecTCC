using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Domain.Entities
{
    public class Curtida
    {
        public int Id { get; set; }
        public Perfil Perfil { get; set; }
        public int IdPerfil { get; set; }
        public Publicacao Publicacao { get; set; }
        public int IdPublicacao { get; set; }
        public DateTime DataCurtida { get; set; }

    }
}
