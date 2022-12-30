using Microsoft.AspNetCore.Mvc;
using SISALM.Entidades.Filtros.Logistica;
using SISALM.Entidades.General;
using SISALM.Entidades.Logistica;
using SISALM.Logicas.Servicios.General;
using SISALM.Logicas.Servicios.Logistica;
using SISALM.WebApp.Commons.Filtros;
using System.Net;

namespace SISALM.WebApp.Areas.Logistica.Controllers
{
    [ModuloLogisticaFiltro]
    public class AlmacenMaterialController : Controller
    {
        private readonly IAlmacenMaterialServicio _almacenMaterialServicio;
        private readonly IMetaDatoServicio _metaDatoServicio;

        public AlmacenMaterialController(IAlmacenMaterialServicio almacenMaterialServicio, IMetaDatoServicio metaDatoServicio)
        {
            _almacenMaterialServicio = almacenMaterialServicio;
            _metaDatoServicio = metaDatoServicio;
        }

        public async Task<IActionResult> Index()
        {
            List<MetaDato> unidadMedidas = await _metaDatoServicio.ListarAsync(new Entidades.Filtros.General.MetaDatoFiltro { Tipo = Entidades.Constantes.TipoMetaDato.UNIDAD_MEDIDA });
            ViewBag.UnidadMedidas = unidadMedidas;
            return View();
        }

        public async Task<IActionResult> Listar(AlmacenMaterialFiltro filtro, int pageIndex, int pageSize)
        {
            try
            {
                List<AlmacenMaterial> lista = await _almacenMaterialServicio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
                int totalRows = await _almacenMaterialServicio.ContarAsync(filtro);
                return Ok(new
                {
                    totalRows,
                    lista = lista.Select(x => new
                    {
                        x.Id,
                        x.AlmacenId,
                        Almacen = new
                        {
                            x.Almacen?.Codigo,
                            x.Almacen?.Nombre,
                            x.Almacen?.Tipo
                        },
                        Material = new
                        {
                            x.Material?.Codigo,
                            x.Material?.Nombre,
                            UnidadMedida = new
                            {
                                x.Material?.UnidadMedida?.Codigo
                            }
                        },
                        x.Cantidad,
                        x.Precio,
                        x.PrecioTotal,
                        x.Periodo
                    })
                });
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_Error");
            }
        }

    }
}
