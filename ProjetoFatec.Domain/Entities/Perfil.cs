﻿using ProjetoFatec.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [Required]
        [Column("Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }
        [Required]
        [Column("Sobrenome")]
        [MaxLength(255)]
        public string Sobrenome { get; set; }
        [Required]
        [MaxLength(11)] 
        public string Telefone { get; set; } //ex. 11900000000
        [Required]
        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [MaxLength(1)]
        [Column("Sexo")]
        public SexoEnum Sexo { get; set; }
        [Column("NomeCurso")]
        public string NomeCurso { get; set; }
        public FotoPerfil? FotoPerfil { get; set; }
        [Column("Biografia")]
        public string? Biografia { get; set; }
        [Column("SemestreAtual")]
        public int SemestreAtual { get; set; }
    }
}
