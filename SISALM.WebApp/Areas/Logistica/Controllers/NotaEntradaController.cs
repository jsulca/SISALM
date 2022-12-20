using Microsoft.AspNetCore.Mvc;
using SISALM.WebApp.Commons.Filtros;

namespace SISALM.WebApp.Areas.Logistica.Controllers
{
    [ModuloLogisticaFiltro]
    public class NotaEntradaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
