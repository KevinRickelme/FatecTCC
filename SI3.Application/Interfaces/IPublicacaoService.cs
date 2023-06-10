using SI3.Application.DTOs;
using SI3.Domain.Entities;

namespace SI3.Application.Interfaces
{
    public interface IPublicacaoService
    {
        bool Add(PublicacaoDTO pb);
        Task<List<Publicacao?>> GetPublicacoes(UsuarioDTO usuario);
        Publicacao GetPublicacao(int idPublicacao);
        int Remove(int idOriginal);
    }
}
