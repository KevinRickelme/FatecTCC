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
    public class CurtidaService : ICurtidaService
    {
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IMapper _mapper;

        public CurtidaService(ICurtidaRepository curtidaRepository, IMapper mapper)
        {
            _curtidaRepository = curtidaRepository;
            _mapper = mapper;
        }
        public int Add(CurtidaDTO curtidaDTO)
        {
            var curtida = _mapper.Map<Curtida>(curtidaDTO);   
            return _curtidaRepository.Add(curtida);
        }

        public int Delete(CurtidaDTO curtidaDTO)
        {
            var curtida = _mapper.Map<Curtida>(curtidaDTO);
            return _curtidaRepository.Delete(curtida);
        }

        public int RemoveAll(int idPublicacao)
        {
            return _curtidaRepository.RemoveAll(idPublicacao);
        }
    }
}
