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
    }
}
