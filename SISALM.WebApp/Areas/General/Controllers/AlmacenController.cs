using Microsoft.AspNetCore.Mvc;
using SISALM.Entidades.General;
using SISALM.Logicas.Servicios.General;
using SISALM.WebApp.Commons.Filtros;

namespace SISALM.WebApp.Areas.General.Controllers
{
    [ModuloGeneralFiltro]
    public class AlmacenController : Controller
    {
        private readonly IAlmacenServicio _almacenServicio;

        public AlmacenController(IAlmacenServicio almacenServicio)
        {
            _almacenServicio = almacenServicio;
        }

        #region Acciones

        public async Task<IActionResult> Index()
        {
            List<Almacen> lista = await _almacenServicio.ListarPorPaginaAsync(null, 1, 10);
            return View();
        }

        #endregion

    }
}
