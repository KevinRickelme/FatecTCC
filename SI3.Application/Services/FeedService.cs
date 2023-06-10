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
