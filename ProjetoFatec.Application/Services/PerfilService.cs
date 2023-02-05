using AutoMapper;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;

namespace ProjetoFatec.Application.Services
{
    public class PerfilService : IPerfilService
    {
        private IPerfilRepository _perfilRepository;
        private IMapper _mapper;

        public PerfilService(IMapper mapper, IPerfilRepository perfilRepository)
        {
            _mapper =mapper;
            _perfilRepository = perfilRepository;
        }

        public bool Add(PerfilViewModel perfil)
        {
            var mapPerfil = _mapper.Map<Perfil>(perfil);
            return _perfilRepository.Add(mapPerfil);
        }

        public async Task<Perfil?> GetPerfil(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfil(mapUsuario);
            return _mapper.Map<Perfil>(result);
        }
    }
}
