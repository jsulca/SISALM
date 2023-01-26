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
    public class NotaSalidaController : Controller
    {
        private readonly INotaSalidaServicio _notaSalidaServicio;
        private readonly IAlmacenServicio _almacenServicio;
        private readonly IAlmacenMaterialServicio _almacenMaterialServicio;

        public NotaSalidaController(INotaSalidaServicio notaSalidaServicio, IAlmacenServicio almacenServicio, IAlmacenMaterialServicio almacenMaterialServicio)
        {
            _notaSalidaServicio = notaSalidaServicio;
            _almacenServicio = almacenServicio;
            _almacenMaterialServicio = almacenMaterialServicio;
        }

        #region Acciones

        public IActionResult Index() => View();

        public async Task<IActionResult> Nuevo()
        {
            try
            {
                List<Almacen> almacenes = await _almacenServicio.ListarAsync(new Entidades.Filtros.General.AlmacenFiltro { Activo = true });
                NotaSalida entidad = new()
                {
                    Estado = Entidades.Constantes.EstadoNotaSalida.FINALIZADO,
                };

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
        public async Task<IActionResult> Nuevo(NotaSalidaModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    NotaSalida entidad = model.Get();

                    await _notaSalidaServicio.GuardarAsync(entidad);

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

        public async Task<IActionResult> Ver(int id)
        {
            try
            {
                NotaSalida? entidad = await _notaSalidaServicio.BuscarPorIdAsync(id, true);
                if (entidad == null) throw new Exception("La nota de salida no se encuentra registrado.");
                return View(entidad);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Listar(NotaSalidaFiltro filtro, int pageIndex, int pageSize)
        {
            try
            {
                List<NotaSalida> lista = await _notaSalidaServicio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
                int totalRows = await _notaSalidaServicio.ContarAsync(filtro);
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
                        x.Estado,
                        x.NroComprobante,
                        NotaEntrada = new { x.NotaEntrada?.Codigo }
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
        private void Validar(NotaSalidaModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (!entidad.Tipo.HasValue) ModelState.AddModelError("Tipo", "Es necesario seleccionar un tipo.");
            if (!entidad.Estado.HasValue) ModelState.AddModelError("Estado", "Es necesario seleccionar un estado.");
            if (string.IsNullOrEmpty(entidad.Descripcion)) ModelState.AddModelError("Descripcion", "Es necesario ingresar una descripción.");
            if (entidad.Materiales.Count == 0) ModelState.AddModelError("Materiales", "Es necesario ingresar materiales.");
            else
            {
                int i = 1;
                foreach (var item in entidad.Materiales)
                {
                    if (item.MaterialId <= 0) ModelState.AddModelError("Materiales_MaterialId_" + i, string.Format("El material nro. {0}, no tiene un identificador.", i));
                    if (item.AlmacenId <= 0) ModelState.AddModelError("Materiales_AlmacenId_" + i, string.Format("El material nro. {0}, es necesario seleccionar un almacen.", i));
                    if (item.Cantidad <= 0) ModelState.AddModelError("Materiales_Cantidad_" + i, string.Format("El material nro. {0}, debe tener una cantidad mayor a cero.", i));

                    i++;
                }
            }
        }

        #endregion
    }
}
