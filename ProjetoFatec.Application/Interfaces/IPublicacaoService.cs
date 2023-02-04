using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;

namespace ProjetoFatec.Application.Interfaces
{
    public interface IPublicacaoService
    {
        bool Add(PublicacaoViewModel pb);
        Task<List<Publicacao?>> GetPublicacoes(UsuarioViewModel usuario);
    }
}
