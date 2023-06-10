using SI3.Application.DTOs;
using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.Interfaces
{
    public interface ICurtidaService
    {
        int Add(CurtidaDTO curtida);
        int Delete(CurtidaDTO curtida);
        int RemoveAll(int idPublicacao);
    }
}
