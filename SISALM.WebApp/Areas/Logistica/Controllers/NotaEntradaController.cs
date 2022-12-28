using Microsoft.AspNetCore.Mvc;
using SISALM.Entidades.Filtros.Logistica;
using SISALM.Entidades.General;
using SISALM.Entidades.Logistica;
using SISALM.Logicas.Servicios.General;
using SISALM.Logicas.Servicios.Logistica;
using SISALM.WebApp.Areas.Logistica.Models;
using SISALM.WebApp.Commons.Filtros;
using System.Net;

namespace SISALM.WebApp.Areas.Logistica.Controllers
{
    [ModuloLogisticaFiltro]
    public class NotaEntradaController : Controller
    {
        private readonly INotaEntradaServicio _notaEntradaServicio;
        private readonly IAlmacenServicio _almacenServicio;

        public NotaEntradaController(INotaEntradaServicio notaEntradaServicio, IAlmacenServicio almacenServicio)
        {
            _notaEntradaServicio = notaEntradaServicio;
            _almacenServicio = almacenServicio;
        }

        #region Acciones

        public IActionResult Index() => View();

        public async Task<IActionResult> Nuevo()
        {
            try
            {
                List<Almacen> almacenes = await _almacenServicio.ListarAsync(new Entidades.Filtros.General.AlmacenFiltro { Activo = true });
                NotaEntrada entidad = new() { Estado = Entidades.Constantes.EstadoNotaEntrada.FINALIZADO };

                ViewBag.Almacenes = almacenes;
                return View(entidad);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(NotaEntradaModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    NotaEntrada entidad = model.Get();

                    await _notaEntradaServicio.GuardarAsync(entidad);

                    return Ok(new
                    {
                        entidad.Id,
                        entidad.Codigo
                    });
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_Error");
            }
        }

        public async Task<IActionResult> Listar(NotaEntradaFiltro filtro, int pageIndex, int pageSize)
        {
            try
            {
                List<NotaEntrada> lista = await _notaEntradaServicio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
                int totalRows = await _notaEntradaServicio.ContarAsync(filtro);
                return Ok(new
                {
                    totalRows,
                    lista = lista.Select(x => new
                    {
                        x.Id,
                        x.Codigo,
                        x.Descripcion,
                        x.Tipo,
                        x.Registro,
                        x.FechaEntrega,
                        x.Estado,
                        x.NroComprobante,
                        NotaSalida = new { x.NotaSalida?.Codigo }
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

        #endregion

        #region Metodos

        [NonAction]
        private void Validar(NotaEntradaModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (!entidad.Tipo.HasValue) ModelState.AddModelError("Tipo", "Es necesario seleccionar un tipo.");
            if (string.IsNullOrEmpty(entidad.Descripcion)) ModelState.AddModelError("Descripcion", "Es necesario ingresar una descripción.");
            if (!entidad.FechaEntrega.HasValue || entidad.FechaEntrega == DateTime.MinValue) ModelState.AddModelError("FechaEntrega", "Es necesario ingresar una fecha de entrega.");
            if (entidad.Materiales.Count == 0) ModelState.AddModelError("Materiales", "Es necesario ingresar materiales.");
            else
            {
                int i = 1;
                foreach (var item in entidad.Materiales)
                {
                    if (item.MaterialId <= 0) ModelState.AddModelError("Materiales_MaterialId_" + i, string.Format("El material nro. {0}, no tiene un identificador.", i));
                    if (item.AlmacenId <= 0) ModelState.AddModelError("Materiales_AlmacenId_" + i, string.Format("El material nro. {0}, es necesario seleccionar un almacen.", i));
                    if (item.Cantidad <= 0) ModelState.AddModelError("Materiales_Cantidad_" + i, string.Format("El material nro. {0}, debe tener una cantidad mayor a cero.", i));
                    if (item.Precio <= 0) ModelState.AddModelError("Materiales_Precio_" + i, string.Format("El material nro. {0}, debe tener un precio mayor a cero.", i));

                    i++;
                }
            }
        }

        #endregion
    }
}
