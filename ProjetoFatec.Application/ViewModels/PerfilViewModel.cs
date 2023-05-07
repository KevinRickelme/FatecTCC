using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.ViewModels
{
    public class PerfilViewModel
    {
        public ICollection<Amigo> Amigos { get; set; }
        public ICollection<Perfil> PerfisDeAmigos { get; set; }
        public Usuario Usuario { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage ="DDD/Telefone é obrigatório")]
        public string Telefone { get; set; } //ex. 11900000000
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Sexo é obrigatório")]
        public SexoEnum Sexo { get; set; }
        [Required(ErrorMessage ="Curso é obrigatório")]
        public string NomeCurso { get; set; }
        
        public FotoPerfil? FotoPerfil { get; set; }
        public string? Biografia { get; set; }
        [Required(ErrorMessage = "O semestre atual é obrigatório")]
        public int SemestreAtual { get; set; }
        [NotMapped]
        public string Email { get; set; }
        public Feed Feed { get; set; }

        public int? IdFotoPerfil { get; set; }

        [NotMapped]
        public ICollection<Publicacao> Publicacoes { get; set; }
        [NotMapped]
        public ICollection<Comentario> Comentarios { get; set; }


    }
}
