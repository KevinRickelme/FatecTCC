using ProjetoFatec.Application.ViewModels;

namespace ProjetoFatec.Application.ViewModels
{
    public class FeedViewModel
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public ICollection<PublicacaoViewModel> Publicacoes { get; set; }
    }
}
