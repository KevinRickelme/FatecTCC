using AutoMapper;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.DTOs;
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

        public bool Add(PerfilDTO perfil)
        {
            var mapPerfil = _mapper.Map<Perfil>(perfil);
            return _perfilRepository.Add(mapPerfil);
        }

        public bool Update(PerfilDTO perfil)
        {
            var mapPerfil = _mapper.Map<Perfil>(perfil);
            return _perfilRepository.Update(mapPerfil);
        }

        public async Task<Perfil?> GetPerfil(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfil(mapUsuario);
            return _mapper.Map<Perfil>(result);
        }
        public async Task<Perfil?> GetPerfil(int idPerfil)
        {
            var result = _perfilRepository.GetPerfil(idPerfil);
            return _mapper.Map<Perfil>(result);
        }

        public async Task<PerfilDTO?> GetPerfilViewModel(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfil(mapUsuario);
            return _mapper.Map<PerfilDTO>(result);
        }

        public async Task<PerfilDTO?> GetPerfilViewModel(int idPerfil)
        {
            var result = _perfilRepository.GetPerfil(idPerfil);
            return _mapper.Map<PerfilDTO>(result);
        }

        public async Task<Perfil?> GetPerfilWithoutNavigation(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _perfilRepository.GetPerfilWithoutNavigation(mapUsuario);
            return _mapper.Map<Perfil>(result);
        }

        public async Task<List<PerfilDTO>> GetPerfisByName(string nome)
        {
            var ArrayNome = nome.Split(' ').ToArray();
            List<Perfil> result;
            if (ArrayNome.Length < 2)
                result = await _perfilRepository.GetPerfisByName(nome);
            else 
            {
                var nomeComposto = ArrayNome.Length;
                result = await _perfilRepository.GetPerfisByFullName(ArrayNome);
            }
            return _mapper.Map<List<PerfilDTO>>(result);
        }
    }
}
