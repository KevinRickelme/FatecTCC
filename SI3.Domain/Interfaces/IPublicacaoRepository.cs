using Microsoft.AspNetCore.Http;
using SI3.Domain.Entities;

namespace SI3.Domain.Interfaces
{
    public interface IPublicacaoRepository
    {
        bool Add(Publicacao pb);
        Task<List<Publicacao?>> GetPublicacoes(Usuario usuario);
        Publicacao GetPublicacao(int id);
        int RemovePublicacao(int idOriginal);
    }
}
