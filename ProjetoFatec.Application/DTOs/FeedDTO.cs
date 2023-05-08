using ProjetoFatec.Application.DTOs;

namespace ProjetoFatec.Application.DTOs
{
    public class FeedDTO
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public ICollection<PublicacaoDTO> Publicacoes { get; set; }
    }
}
