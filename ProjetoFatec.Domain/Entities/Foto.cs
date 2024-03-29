﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    [Table("Foto")]
    public class Foto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public Publicacao Publicacao { get; set; }
        [Required]
        [Column("CaminhoFoto")]
        public string CaminhoFoto { get; set; }
    }
}