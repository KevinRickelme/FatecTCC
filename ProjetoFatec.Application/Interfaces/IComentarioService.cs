using ProjetoFatec.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Interfaces
{
    public interface IComentarioService
    {
        int Add(ComentarioDTO comentarioDTO);
    }
}
