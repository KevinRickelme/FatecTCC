using Microsoft.AspNetCore.Mvc;

namespace ProjetoFatec.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
