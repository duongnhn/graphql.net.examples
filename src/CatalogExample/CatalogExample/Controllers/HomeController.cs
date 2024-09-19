using Microsoft.AspNetCore.Mvc;

namespace CatalogExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
