using SI3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.Interfaces
{
    public interface IComentarioService
    {
        int Add(ComentarioDTO comentarioDTO);
        int RemoveAll(int idPublicacao);
    }
}
