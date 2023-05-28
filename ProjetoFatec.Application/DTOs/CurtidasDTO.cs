using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.DTOs
{
    public class CurtidaDTO
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int IdPublicacao { get; set; }
        public DateTime DataCurtida { get; set; }
    }
}
