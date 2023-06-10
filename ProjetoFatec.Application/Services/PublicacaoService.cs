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
        private IPerfilRepository _perfilRepository;
        private IMapper _mapper;
        private IComentarioRepository _comentarioRepository;

        public PublicacaoService(IMapper mapper, IPublicacaoRepository publicacaoRepository, IPerfilRepository perfilRepository, IComentarioRepository comentarioRepository)
        {
            _mapper = mapper;
            _publicacaoRepository = publicacaoRepository;
            _perfilRepository = perfilRepository;
            _comentarioRepository = comentarioRepository;
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

        public Publicacao GetPublicacao(int idPublicacao)
        {
            var result = _publicacaoRepository.GetPublicacao(idPublicacao);
            result.Comentarios = _comentarioRepository.GetComentarios(idPublicacao);
                if (result.Comentarios != null)
                {
                    foreach (var comentario in result.Comentarios)
                    {
                        comentario.Perfil = _perfilRepository.GetPerfil(comentario.IdPerfil);
                    }
                }


            return result;
        }

        public int Remove(int idOriginal)
        {
            return _publicacaoRepository.RemovePublicacao(idOriginal);
        }
    }
}
