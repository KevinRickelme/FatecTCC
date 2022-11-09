using System.ComponentModel.DataAnnotations;

namespace ProjetoFatec.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A {0} é obrigatória.")]
        public string Senha { get; set; }
    }
}
