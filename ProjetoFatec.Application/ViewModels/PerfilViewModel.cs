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
        public int Id { get; set; }
        public ICollection<Amigo> Amigos { get; set; }
        public ICollection<Perfil> PerfisDeAmigos { get; set; }
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; } //ex. 11900000000
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string NomeCurso { get; set; }
        public FotoPerfil? FotoPerfil { get; set; }
        public string? Biografia { get; set; }
        public int SemestreAtual { get; set; }
        [NotMapped]
        public string Email { get; set; }
        public Feed Feed { get; set; }

    }
}
