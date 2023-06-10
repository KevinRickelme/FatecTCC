using AutoMapper;
using SI3.Application.Interfaces;
using SI3.Application.DTOs;
using SI3.Domain.Entities;
using SI3.Domain.Interfaces;

namespace SI3.Application.Services
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

        public bool Update(Perfil perfil)
        {
            return _perfilRepository.Update(perfil);
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

        public async Task<List<PerfilDTO>> GetPerfisAmigosById(int Id)
        {
            List<Perfil> result = await _perfilRepository.GetPerfisAmigosById(Id);
            return _mapper.Map<List<PerfilDTO>>(result);
        }

        public async Task<int> SalvarFotoPerfil(FotoPerfil fp)
        {
            return await _perfilRepository.SalvarFotoPerfil(fp);
        }
    }
}
