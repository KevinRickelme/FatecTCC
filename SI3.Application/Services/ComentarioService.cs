using AutoMapper;
using SI3.Application.DTOs;
using SI3.Application.Interfaces;
using SI3.Domain.Entities;
using SI3.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;
        private IMapper _mapper;
        public ComentarioService(IComentarioRepository comentarioRepository, IMapper mapper)
        {
            _comentarioRepository = comentarioRepository;
            _mapper = mapper;
        }
        public int Add(ComentarioDTO comentarioDTO)
        {
            var mapComentario = _mapper.Map<Comentario>(comentarioDTO);
            return _comentarioRepository.Add(mapComentario);
        }

        public int RemoveAll(int idPublicacao)
        {
            return _comentarioRepository.RemoveAll(idPublicacao);
        }
    }
}
