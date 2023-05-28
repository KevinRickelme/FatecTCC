using ProjetoFatec.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    public sealed class Publicacao : Entity
    {
        public Perfil? Perfil { get; set; }
        public int IdPerfil { get; set; }


        public string Legenda { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<Curtida>? Curtidas { get; set; }

        public string? CaminhoFoto { get; private set; }

        public Publicacao(string legenda, DateTime dataCriacao, string? caminhoFoto)
        {
            ValidateDomain(legenda);
            Legenda = legenda;
            DataCriacao = dataCriacao;
            CaminhoFoto = caminhoFoto;
        }
        public Publicacao(int id, string legenda, DateTime dataCriacao, string? caminhoFoto)
        {
            DomainExceptionValidation.When(id == 0, "Id inválido");
            Id = id;
            Legenda = legenda;
            DataCriacao = dataCriacao;
            CaminhoFoto = caminhoFoto;
        }

        public void Update(string legenda, DateTime dataCriacao, string? caminhoFoto, int idPerfil)
        {
            ValidateDomain(legenda);
            IdPerfil = idPerfil;
        }

        private void ValidateDomain(string legenda)
        {
            DomainExceptionValidation.When(legenda.Split(' ').ToArray().Length > 300, "O número máximo de palavras é 300.");
        }


        

    }
}
