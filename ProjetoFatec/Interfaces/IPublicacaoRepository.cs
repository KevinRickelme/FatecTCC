using ProjetoFatec.Models;

namespace ProjetoFatec.Interfaces
{
    public interface IPublicacaoRepository
    {
        public bool PostarPublicacao(IFormCollection formularioPublicacao, Perfil idPerfil);
    }
}
