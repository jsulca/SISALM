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
        private readonly IAlmacenMaterialServicio _almacenMaterialServicio;

        public NotaEntradaController(INotaEntradaServicio notaEntradaServicio, IAlmacenServicio almacenServicio, IAlmacenMaterialServicio almacenMaterialServicio)
        {
            _notaEntradaServicio = notaEntradaServicio;
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
                NotaEntrada entidad = new()
                {
                    Estado = Entidades.Constantes.EstadoNotaEntrada.FINALIZADO,
                    FechaEntrega = DateTime.Today
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

        [HttpPost]
        public async Task<IActionResult> Anular(int id)
        {
            try
            {
                if (id <= 0) ModelState.AddModelError("Id", "Es necesario ingresar un identificador.");
                if(ModelState.IsValid)
                {
                    NotaEntrada? notaEntrada = await _notaEntradaServicio.BuscarPorIdAsync(id, true);
                    if (notaEntrada == null) ModelState.AddModelError("Id", "La nota de entrada no existe.");
                    else if (notaEntrada.Estado != Entidades.Constantes.EstadoNotaEntrada.FINALIZADO) ModelState.AddModelError("Estado", "La nota de entrada no se encuentra en el estado de FINALIZADO.");
                    else
                    {
                        //TODO: VERIFICAR EL STOCK DE MATERIALES Y ALMACENES
                        List<int> materialIds = new(),
                            almacenIds = new();

                        foreach (var item in notaEntrada.Materiales!)
                        {
                            materialIds.Add(item.MaterialId);
                            almacenIds.Add(item.AlmacenId);
                        }

                        List<AlmacenMaterial> inventarios = await _almacenMaterialServicio.ListarAsync(new AlmacenMaterialFiltro
                        {
                            AlmacenIds = almacenIds.ToArray(),
                            MaterialIds = materialIds.ToArray()
                        });

                        AlmacenMaterial? inventario;

                        foreach (var item in notaEntrada.Materiales!)
                        {
                            switch (item.Almacen!.Tipo)
                            {
                                case Entidades.Constantes.TipoAlmacen.PROMEDIO:
                                    inventario = inventarios.SingleOrDefault(x => x.AlmacenId == item.AlmacenId && x.MaterialId == item.MaterialId);

                                    if (inventario == null) ModelState.AddModelError("Inventario", $"No existe el material {item.Material!.Codigo} en el almacen {item.Almacen!.Codigo}");
                                    else if (inventario.Cantidad < item.Cantidad) ModelState.AddModelError("Inventario", $"No hay una existencia válida del material {item.Material!.Codigo} en el almacen {item.Almacen!.Codigo}");

                                    break;
                                case Entidades.Constantes.TipoAlmacen.PEPS:
                                case Entidades.Constantes.TipoAlmacen.UEPS:
                                    inventario = inventarios.SingleOrDefault(x => x.AlmacenId == item.AlmacenId && x.MaterialId == item.MaterialId && x.Precio == item.Precio && x.Periodo == notaEntrada.Registro);

                                    if (inventario == null) ModelState.AddModelError("Inventario", $"No existe el material {item.Material!.Codigo} en el almacen {item.Almacen!.Codigo}");
                                    else if (inventario.Cantidad < item.Cantidad) ModelState.AddModelError("Inventario", $"No hay una existencia válida del material {item.Material!.Codigo} en el almacen {item.Almacen!.Codigo}");
                                    break;
                            }
                        }
                    }
                }
                if (ModelState.IsValid)
                {
                    NotaEntrada entidad = new() { Id = id };
                    await _notaEntradaServicio.AnularAsync(entidad);

                    return Ok(new { entidad.Id });
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
                NotaEntrada? entidad = await _notaEntradaServicio.BuscarPorIdAsync(id, true);
                if (entidad == null) throw new Exception("La nota de entrada no se encuentra registrado.");
                return View(entidad);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
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
