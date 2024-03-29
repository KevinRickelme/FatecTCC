﻿using ProjetoFatec.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    [Table("Amigo")]
    public class Amigo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdPerfilSolicitante")]
        public Perfil PerfilSolicitante { get; set; }
        public StatusAmizadeEnum Status { get; set; } = StatusAmizadeEnum.Pendente;
        [Required]
        [Column("DataAmizade")]
        public DateTime DataAmizade { get; set; }
    }
}
