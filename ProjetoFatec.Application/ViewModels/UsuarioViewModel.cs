using ProjetoFatec.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public PrivilegioEnum Privilegio { get; set; }
        public StatusUsuarioEnum Status { get; set; }


    }
}
