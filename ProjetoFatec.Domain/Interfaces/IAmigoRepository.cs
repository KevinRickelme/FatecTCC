﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Domain.Interfaces
{
    public interface IAmigoRepository
    {
        bool EnviarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado);
        bool AceitarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado);
        bool RecusarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado);
    }
}
