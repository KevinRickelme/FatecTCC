using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.DTOs
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public int IdPublicacao { get; set; }
        public DateTime DataComentario { get; set; }
    }
}
