using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}