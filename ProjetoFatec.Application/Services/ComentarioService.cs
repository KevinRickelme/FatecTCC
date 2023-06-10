using AutoMapper;
using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Services
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
