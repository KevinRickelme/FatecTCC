using ProjetoFatec.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    public class Publicacao : Entity
    {
        public Perfil? Perfil { get; private set; }
        public int IdPerfil { get; private set; }


        public string Legenda { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public ICollection<Comentario>? Comentarios { get; private set; }

        public string? CaminhoFoto { get; private set; }

        /*public Publicacao(string legenda, DateTime dataCriacao, string? caminhoFoto)
        {
            //ValidateDomain(legenda, dataCriacao, caminhoFoto);
            Legenda = legenda;
            DataCriacao = dataCriacao;
            CaminhoFoto = caminhoFoto;
            //Perfil = perfil;
        }*/

        private void ValidateDomain(string legenda, DateTime dataCriacao, string? caminhoFoto)
        {
            throw new NotImplementedException();
        }

        public Publicacao()
        {

        }
        public Publicacao(int id, string legenda, DateTime dataCriacao, string? caminhoFoto, ICollection<Comentario> comentarios, Perfil perfil)
        {
            Id = id;
            Legenda = legenda;
            DataCriacao = dataCriacao;
            CaminhoFoto = caminhoFoto;
            Comentarios = comentarios;
            Perfil = perfil;
        }

    }
}
