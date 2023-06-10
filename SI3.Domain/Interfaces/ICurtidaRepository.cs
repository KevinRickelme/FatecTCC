using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Domain.Interfaces
{
    public interface ICurtidaRepository
    {
        int Add(Curtida curtida);
        int Delete(Curtida curtida);
        int RemoveAll(int idPublicacao);
    }
}
