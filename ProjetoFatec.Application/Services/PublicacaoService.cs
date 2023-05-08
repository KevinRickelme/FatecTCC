using AutoMapper;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;

namespace ProjetoFatec.Application.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private IPublicacaoRepository _publicacaoRepository;
        private IMapper _mapper;

        public PublicacaoService(IMapper mapper, IPublicacaoRepository publicacaoRepository)
        {
            _mapper = mapper;
            _publicacaoRepository = publicacaoRepository;
        }

        public bool Add(PublicacaoDTO publicacao)
        {
            var mapPublicacao = _mapper.Map<Publicacao>(publicacao);
            return _publicacaoRepository.Add(mapPublicacao);
        }

        public async Task<List<Publicacao?>> GetPublicacoes(UsuarioDTO usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            var result = await _publicacaoRepository.GetPublicacoes(mapUsuario);
            return _mapper.Map<List<Publicacao?>>(result);
        }
    }
}
