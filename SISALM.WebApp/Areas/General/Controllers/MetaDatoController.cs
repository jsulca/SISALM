using Microsoft.AspNetCore.Mvc;
using SISALM.WebApp.Commons.Filtros;

namespace SISALM.WebApp.Areas.General.Controllers
{
    [ModuloGeneralFiltro]
    public class MetaDatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
