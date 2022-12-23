using Microsoft.AspNetCore.Mvc;
using SISALM.WebApp.Models;

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
