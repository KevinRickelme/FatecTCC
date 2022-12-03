using ProjetoFatec.Models;
using ProjetoFatec.ViewModels;
using System.Security.Claims;

namespace ProjetoFatec.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(CookiesViewModel cvm);
        bool PrimeiroAcesso(CookiesViewModel cvm);
        Usuario? GetUsuario(string email);
        bool CadastrarPerfilDeUsuario(IFormCollection formularioCadastro, string emailUsuario);

        Perfil GetPerfil(CookiesViewModel cvm);
        bool TemPerfilCriado(CookiesViewModel cvm);
    }
}
