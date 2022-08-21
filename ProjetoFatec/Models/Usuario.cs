using System.ComponentModel.DataAnnotations;

namespace ProjetoFatec.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string UsuarioNome { get; set; }
        public string Email { get; set; }
        public string UsuarioSenha { get; set; }
       public int Privilegio { get; set; }


    }
}
