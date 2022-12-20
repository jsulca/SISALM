using Microsoft.AspNetCore.Mvc;
using SISALM.WebApp.Commons.Filtros;

namespace SISALM.WebApp.Areas.Logistica.Controllers
{
    [ModuloLogisticaFiltro]
    public class NotaSalidaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
