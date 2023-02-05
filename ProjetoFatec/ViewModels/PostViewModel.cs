using System.Web;
namespace ProjetoFatec.ViewModels
{
    public class PostViewModel
    {
        public string postagem { get; set; }
        public IFormFile? imagem { get; set; }

    }
}
