using System.Web;
namespace ProjetoFatec.ViewModels
{
    public class PostViewModel
    {
        public string postagem { get; set; }
        public IFormFileCollection imagem { get; set; }

    }
}
