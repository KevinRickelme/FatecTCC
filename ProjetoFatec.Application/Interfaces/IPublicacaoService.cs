using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;

namespace ProjetoFatec.Application.Interfaces
{
    public interface IPublicacaoService
    {
        bool Add(PublicacaoDTO pb);
        Task<List<Publicacao?>> GetPublicacoes(UsuarioDTO usuario);
        Publicacao GetPublicacao(int idPublicacao);
    }
}
