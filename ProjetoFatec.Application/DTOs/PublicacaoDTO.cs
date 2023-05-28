using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjetoFatec.Application.DTOs
{
    public class PublicacaoDTO
    {
        public Perfil Perfil { get; set; }
        public string Legenda { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Comentario>? Comentario { get; set; }
        public List<CurtidaDTO>? Curtida { get; set; }
        public string? CaminhoFoto { get; set; }
        [NotMapped]
        public IFormFile? imagem { get; set; }
    }
}
