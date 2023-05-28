using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Interfaces
{
    public interface ICurtidaService
    {
        int Add(CurtidaDTO curtida);
        int Delete(CurtidaDTO curtida);
    }
}
