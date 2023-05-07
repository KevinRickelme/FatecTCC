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

        public bool Update(PerfilViewModel perfil)
        {
            var mapPerfil = _mapper.Map<Perfil>(perfil);
            return _perfilRepository.Update(mapPerfil);
        }

        public async Task<Perfil?> GetPerfil(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfil(mapUsuario);
            return _mapper.Map<Perfil>(result);
        }
        public async Task<Perfil?> GetPerfil(int idPerfil)
        {
            var result = await _perfilRepository.GetPerfil(idPerfil);
            return _mapper.Map<Perfil>(result);
        }

        public async Task<PerfilViewModel?> GetPerfilViewModel(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfil(mapUsuario);
            return _mapper.Map<PerfilViewModel>(result);
        }

        public async Task<PerfilViewModel?> GetPerfilViewModel(int idPerfil)
        {
            var result = await _perfilRepository.GetPerfil(idPerfil);
            return _mapper.Map<PerfilViewModel>(result);
        }

        public async Task<Perfil?> GetPerfilSemAmigo(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfilSemAmigo(mapUsuario);
            return _mapper.Map<Perfil>(result);
        }
    }
}
