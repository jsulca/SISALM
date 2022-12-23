using Microsoft.AspNetCore.Mvc;
using SISALM.Entidades.Filtros.General;
using SISALM.Entidades.General;
using SISALM.Logicas.Servicios.General;
using SISALM.WebApp.Areas.General.Models;
using SISALM.WebApp.Commons.Filtros;
using System.Net;

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

        public IActionResult Index() => View();

        public IActionResult Nuevo(string callBack = "SetNuevo")
        {
            Almacen model = new() { Activo = true, Tipo = Entidades.Constantes.TipoAlmacen.PROMEDIO };
            ViewBag.CallBack = callBack;
            return PartialView("_Nuevo", model);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(AlmacenModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if(ModelState.IsValid)
                {
                    Almacen entidad = model.Get();
                    await _almacenServicio.GuardarAsync(entidad);
                    return Ok(new
                    {
                        entidad.Id
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

        public async Task<IActionResult> Editar(int id, string callBack = "SetEditar")
        {
            try
            {
                Almacen? model = await _almacenServicio.BuscarPorIdAsync(id);
                if (model == null) throw new Exception("No existe el almacen.");
                ViewBag.CallBack = callBack;
                return PartialView("_Editar", model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AlmacenModel.Editar model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    Almacen entidad = model.Get();
                    await _almacenServicio.ActualizarAsync(entidad);
                    return Ok(new
                    {
                        entidad.Id
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

        public async Task<IActionResult> Listar(AlmacenFiltro filtro, int pageIndex, int pageSize)
        {
            try
            {
                List<Almacen> lista = await _almacenServicio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
                int totalRows = await _almacenServicio.ContarAsync(filtro);
                return Ok(new
                {
                    totalRows,
                    lista = lista.Select(x => new
                    {
                        x.Id,
                        x.Codigo,
                        x.Nombre,
                        x.Direccion,
                        x.Activo,
                        x.Tipo,
                        x.Registro
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
        void Validar(AlmacenModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(entidad.Codigo)) ModelState.AddModelError("Codigo", "Es necesario ingresar el código.");
            if(!entidad.Tipo.HasValue) ModelState.AddModelError("Tipo", "Es necesario seleccionar un tipo.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
        }

        [NonAction]
        void Validar(AlmacenModel.Editar entidad)
        {
            ModelState.Clear();
            if (!entidad.Id.HasValue) ModelState.AddModelError("Id", "Es necesario tener un identificador.");
            if (string.IsNullOrEmpty(entidad.Codigo)) ModelState.AddModelError("Codigo", "Es necesario ingresar el código.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
        }

        #endregion

    }
}
