using SI3.Domain.Enums;
using SI3.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SI3.Domain.Entities
{

    public sealed class Perfil : Entity
    {
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Telefone { get; private set; } //ex. 11900000000
        public DateTime DataNascimento { get; private set; }
        public SexoEnum Sexo { get; private set; }
        public string NomeCurso { get; private set; }

        public FotoPerfil? FotoPerfil { get; set; }
        public int? IdFotoPerfil { get; set; }

        public string? Biografia { get; private set; }
        public string? Sobre { get; private set; }
        public int SemestreAtual { get; private set; }

        public ICollection<Publicacao> Publicacoes { get; set; }
        public ICollection<Publicacao> PublicacoesCompartilhadas { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<Curtida> Curtidas { get; set; }
        [NotMapped]
        public List<Perfil> PerfisDeAmigos { get; set; }

        public Feed? Feed { get; set; }
        public int? IdFeed { get; set; }
        public ICollection<Amigo> Amigos { get; set; }

        public Perfil() { }
        public Perfil(string nome, string sobrenome, string telefone, DateTime dataNascimento, SexoEnum sexo, string nomeCurso, string? biografia, int semestreAtual, string? sobre)
        {
            ValidateDomain(nome, sobrenome, telefone, dataNascimento, sexo, nomeCurso, biografia, semestreAtual, sobre);
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            NomeCurso = nomeCurso;
            Biografia = biografia;
            SemestreAtual = semestreAtual;
            Sobre = sobre;
        }


        private void ValidateDomain(string nome, string sobrenome, string telefone, DateTime dataNascimento, SexoEnum sexo, string? nomeCurso, string? biografia, int semestreAtual, string? sobre)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainExceptionValidation.When(String.IsNullOrEmpty(sobrenome), "Sobrenome é obrigatório");
            DomainExceptionValidation.When(String.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            DomainExceptionValidation.When(String.IsNullOrEmpty(nomeCurso), "Nome do curso é obrigatório");
            if (biografia != null)
                DomainExceptionValidation.When(biografia.Split(' ').ToArray().Length > 50, "Nome do curso é obrigatório");
            if(sobre != null)
                DomainExceptionValidation.When(sobre.Split(' ').ToArray().Length > 300, "Nome do curso é obrigatório");
            DomainExceptionValidation.When(semestreAtual <= 0, "O semestre precisa ser maior do que zero");
            DomainExceptionValidation.When(semestreAtual > 6, "Cursos tecnólogos ofereridos pela FATEC possuem no máximo 6 semestres");

            Telefone = Regex.Replace(telefone, "[^0-9]+", "");

        }
    }
}
