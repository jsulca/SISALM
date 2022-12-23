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
    public class MetaDatoController : Controller
    {
        private readonly IMetaDatoServicio _metaDatoServicio;

        public MetaDatoController(IMetaDatoServicio metaDatoServicio)
        {
            _metaDatoServicio = metaDatoServicio;
        }

        #region Acciones

        public IActionResult Index() => View();

        public IActionResult Nuevo(string callBack = "SetNuevo")
        {
            MetaDato model = new() { Activo = true };
            ViewBag.CallBack = callBack;
            return PartialView("_Nuevo", model);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(MetaDatoModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    MetaDato entidad = model.Get();
                    await _metaDatoServicio.GuardarAsync(entidad);
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
                MetaDato? model = await _metaDatoServicio.BuscarPorIdAsync(id);
                if (model == null) throw new Exception("No existe el metadato.");
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
        public async Task<IActionResult> Editar(MetaDatoModel.Editar model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    MetaDato entidad = model.Get();
                    await _metaDatoServicio.ActualizarAsync(entidad);
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

        public async Task<IActionResult> Listar(MetaDatoFiltro filtro, int pageIndex, int pageSize)
        {
            try
            {
                List<MetaDato> lista = await _metaDatoServicio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
                int totalRows = await _metaDatoServicio.ContarAsync(filtro);
                return Ok(new
                {
                    totalRows,
                    lista = lista.Select(x => new
                    {
                        x.Id,
                        x.Codigo,
                        x.Nombre,
                        x.Activo,
                        x.Tipo,
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
        void Validar(MetaDatoModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (!entidad.Tipo.HasValue) ModelState.AddModelError("Tipo", "Es necesario seleccionar un tipo.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
        }

        [NonAction]
        void Validar(MetaDatoModel.Editar entidad)
        {
            ModelState.Clear();
            if (!entidad.Id.HasValue) ModelState.AddModelError("Id", "Es necesario tener un identificador.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
        }

        #endregion
    }
}
