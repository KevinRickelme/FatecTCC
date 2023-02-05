using AutoMapper;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void Add(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            _usuarioRepository.Add(mapUsuario);
        }

        public async Task<UsuarioViewModel?> GetUsuarioViewModel(string email)
        {
            var result = await _usuarioRepository.GetUsuario(email);
            return _mapper.Map<UsuarioViewModel>(result);
        }

        public bool PrimeiroAcesso(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = _usuarioRepository.PrimeiroAcesso(mapUsuario);
            return result;
        }

        public bool TemPerfilCriado(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = _usuarioRepository.TemPerfilCriado(mapUsuario);
            return result;
        }

        public async Task<Usuario> GetUsuario(string email)
        {
            var result = await _usuarioRepository.GetUsuario(email);
            return _mapper.Map<Usuario>(result);
        }
    }
}
