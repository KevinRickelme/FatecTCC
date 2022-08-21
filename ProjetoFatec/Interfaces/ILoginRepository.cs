using ProjetoFatec.Models;
using System.Security.Claims;

namespace ProjetoFatec.Interfaces
{
    public interface ILoginRepository
    {

        Task<ClaimsPrincipal> Login(LoginViewModel vm);
    }
}
