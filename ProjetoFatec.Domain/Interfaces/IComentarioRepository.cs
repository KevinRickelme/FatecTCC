using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Domain.Interfaces
{
    public interface IComentarioRepository
    {
        int Add(Comentario comentario);
        ICollection<Comentario?> GetComentarios(int idPublicacao);
        int RemoveAll(int idPublicacao);
    }
}
