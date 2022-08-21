using Microsoft.AspNetCore.Mvc;

namespace ProjetoFatec.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
