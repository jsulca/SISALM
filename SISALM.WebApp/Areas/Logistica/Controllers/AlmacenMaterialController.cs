using Microsoft.AspNetCore.Mvc;
using SISALM.WebApp.Commons.Filtros;

namespace SISALM.WebApp.Areas.Logistica.Controllers
{
    [ModuloLogisticaFiltro]
    public class AlmacenMaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
