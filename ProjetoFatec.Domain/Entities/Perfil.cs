using ProjetoFatec.Domain.Enums;
using ProjetoFatec.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProjetoFatec.Domain.Entities
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
        public int SemestreAtual { get; private set; }

        public ICollection<Publicacao> Publicacoes {get;set;}

        public ICollection<Comentario> Comentarios { get; set; }
        [NotMapped]
        public List<Perfil> PerfisDeAmigos { get; set; }

        public Feed? Feed { get; set; }
        public int? IdFeed { get; set; }
        public ICollection<Amigo> Amigos { get; set; }

        public Perfil(string nome, string sobrenome, string telefone, DateTime dataNascimento, SexoEnum sexo, string nomeCurso, string? biografia, int semestreAtual)
        {
            ValidateDomain(nome, sobrenome, telefone, dataNascimento, sexo, nomeCurso, biografia, semestreAtual);
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            NomeCurso = nomeCurso;
            Biografia = biografia;
            SemestreAtual = semestreAtual;
        }

        public Perfil(int id, string nome, string sobrenome, string telefone, DateTime dataNascimento, SexoEnum sexo, string nomeCurso, string? biografia, int semestreAtual)
         {
            DomainExceptionValidation.When(id == 0, "Perfil inválido ou excluído");
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            NomeCurso = nomeCurso;
            Biografia = biografia;
            SemestreAtual = semestreAtual;
        }

        private void ValidateDomain(string nome, string sobrenome, string telefone, DateTime dataNascimento, SexoEnum sexo, string? nomeCurso, string? biografia, int semestreAtual)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainExceptionValidation.When(String.IsNullOrEmpty(sobrenome), "Sobrenome é obrigatório");
            DomainExceptionValidation.When(String.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            DomainExceptionValidation.When(String.IsNullOrEmpty(nomeCurso), "Nome do curso é obrigatório");
            DomainExceptionValidation.When(semestreAtual == null, "É necessário informar um semestre");

            Telefone = Regex.Replace(telefone, "[^0-9]+", "");

        }
    }
}
