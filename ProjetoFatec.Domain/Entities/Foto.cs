using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFatec.Domain.Entities
{
    public class Foto
    {

        public int Id { get; set; }
        public int IdPublicacao { get; set; }
        public string CaminhoFoto { get; set; }
    }
}