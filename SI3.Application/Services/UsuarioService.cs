using AutoMapper;
using SI3.Application.Interfaces;
using SI3.Application.DTOs;
using SI3.Domain.Entities;
using SI3.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.Services
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

        public void Add(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            _usuarioRepository.Add(mapUsuario);
        }
        public void Update(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            _usuarioRepository.Update(mapUsuario);
        }

        public async Task<UsuarioDTO?> GetUsuarioViewModel(string email)
        {
            var result = await _usuarioRepository.GetUsuario(email);
            return _mapper.Map<UsuarioDTO>(result);
        }

        public bool PrimeiroAcesso(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = _usuarioRepository.PrimeiroAcesso(mapUsuario);
            return result;
        }

        public bool TemPerfilCriado(UsuarioDTO usuario)
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

        public async Task<Usuario> GetUsuarioAsNoTracking(string email)
        {
            var result = await _usuarioRepository.GetUsuarioAsNoTracking(email);
            return _mapper.Map<Usuario>(result);
        }

        public void AtualizarIdPerfil(string usuario, int IdPerfil)
        {
            var usuarioDTO = GetUsuario(usuario).Result;
            usuarioDTO.IdPerfil = IdPerfil;
            _usuarioRepository.Update(usuarioDTO);
        }
    }
}
