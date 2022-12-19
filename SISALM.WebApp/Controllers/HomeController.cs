using Microsoft.AspNetCore.Mvc;

namespace SISALM.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
