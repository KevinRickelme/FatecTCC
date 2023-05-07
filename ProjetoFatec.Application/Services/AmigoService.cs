using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Services
{
    public class AmigoService : IAmigoService
    {
        private readonly IAmigoRepository _amigoRepository;
        public AmigoService(IAmigoRepository amigoRepository)
        {
            _amigoRepository = amigoRepository;
        }
        public bool AceitarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {
            return _amigoRepository.AceitarSolicitacao(IdPerfilSolicitante, IdPerfilSolicitado);
        }

        public bool EnviarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {
            return _amigoRepository.EnviarSolicitacao(IdPerfilSolicitante, IdPerfilSolicitado);
        }

        public bool RecusarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {
            return _amigoRepository.RecusarSolicitacao(IdPerfilSolicitante, IdPerfilSolicitado);
        }
    }
}
