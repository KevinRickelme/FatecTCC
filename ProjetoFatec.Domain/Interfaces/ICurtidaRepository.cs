using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Domain.Interfaces
{
    public interface ICurtidaRepository
    {
        int Add(Curtida curtida);
        int Delete(Curtida curtida);
    }
}
