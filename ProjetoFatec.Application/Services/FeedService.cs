using AutoMapper;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Services
{
    public class FeedService : IFeedService
    {
        private IMapper _mapper;
        private readonly IFeedRepository _feedRepository;

        public FeedService(IMapper mapper, IFeedRepository feedRepository)
        {
            _mapper = mapper;
            _feedRepository = feedRepository;
        }
        public bool Add(FeedDTO feed)
        {
            var mapFeed = _mapper.Map<Feed>(feed);
            return _feedRepository.Add(mapFeed);
        }

        public async Task<Feed> GetFeed(int IdPerfil)
        {
            return await _feedRepository.GetFeed(IdPerfil);
        }

        public async Task<FeedDTO> GetFeedViewModel(int IdPerfil)
        {
            var result = _feedRepository.GetFeed(IdPerfil);
            return _mapper.Map<FeedDTO>(result);
        }
    }
}
