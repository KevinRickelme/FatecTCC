using SI3.Application.DTOs;

namespace SI3.Application.DTOs
{
    public class FeedDTO
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public ICollection<PublicacaoDTO> Publicacoes { get; set; }
    }
}
