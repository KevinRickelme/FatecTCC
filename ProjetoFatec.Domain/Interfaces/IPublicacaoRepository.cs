using Microsoft.AspNetCore.Http;
using ProjetoFatec.Domain.Entities;

namespace ProjetoFatec.Domain.Interfaces
{
    public interface IPublicacaoRepository
    {
        bool Add(Publicacao pb);
        Task<List<Publicacao?>> GetPublicacoes(Usuario usuario);
        Publicacao GetPublicacao(int id);
    }
}
