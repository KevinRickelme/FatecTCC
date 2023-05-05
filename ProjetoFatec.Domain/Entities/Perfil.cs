using ProjetoFatec.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{

    public class Perfil
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; } //ex. 11900000000
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string NomeCurso { get; set; }

        public FotoPerfil? FotoPerfil { get; set; }
        public int? IdFotoPerfil { get; set; }

        public string? Biografia { get; set; }
        public int SemestreAtual { get; set; }

        public ICollection<Publicacao> Publicacoes {get;set;}

        public ICollection<Comentario> Comentarios { get; set; }
        [NotMapped]
        public List<Perfil> PerfisDeAmigos { get; set; }

        public Feed? Feed { get; set; }
        public int? IdFeed { get; set; }
        public ICollection<Amigo> Amigos { get; set; }
    }
}
