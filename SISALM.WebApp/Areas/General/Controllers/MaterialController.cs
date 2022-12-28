using Microsoft.AspNetCore.Mvc;
using SISALM.Entidades.Filtros.General;
using SISALM.Entidades.General;
using SISALM.Logicas.Servicios.General;
using SISALM.WebApp.Areas.General.Models;
using SISALM.WebApp.Commons.Filtros;
using System.Dynamic;
using System.Net;

namespace SISALM.WebApp.Areas.General.Controllers
{
    [ModuloGeneralFiltro]
    public class MaterialController : Controller
    {
        private readonly IMaterialServicio _materialServicio;
        private readonly IMetaDatoServicio _metaDatoServicio;

        public MaterialController(IMaterialServicio materialServicio, IMetaDatoServicio metaDatoServicio)
        {
            _materialServicio = materialServicio;
            _metaDatoServicio = metaDatoServicio;
        }

        #region Acciones

        public async Task<IActionResult> Index()
        {
            try
            {
                List<MetaDato> unidadMedidas = await _metaDatoServicio.ListarAsync(new MetaDatoFiltro { Activo = true, Tipo = Entidades.Constantes.TipoMetaDato.UNIDAD_MEDIDA });
                ViewBag.UnidadMedidas = unidadMedidas;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Nuevo(string callBack = "SetNuevo")
        {
            try
            {
                Material model = new() { Activo = true };
                List<MetaDato> unidadMedidas = await _metaDatoServicio.ListarAsync(new MetaDatoFiltro { Activo = true, Tipo = Entidades.Constantes.TipoMetaDato.UNIDAD_MEDIDA });

                ViewBag.UnidadMedidas = unidadMedidas;
                ViewBag.CallBack = callBack;

                return PartialView("_Nuevo", model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_Error");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(MaterialModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    bool existeCodigo = await _materialServicio.CountByAsync(x => x.Codigo == model.Codigo) > 0;
                    if (existeCodigo) ModelState.AddModelError("Codigo", "Ya existe un material con el código ingresado.");
                }
                if (ModelState.IsValid)
                {
                    Material entidad = model.Get();
                    await _materialServicio.GuardarAsync(entidad);
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
                Material? model = await _materialServicio.BuscarPorIdAsync(id);
                if (model == null) throw new Exception("No existe el material.");

                List<MetaDato> unidadMedidas = await _metaDatoServicio.ListarAsync(new MetaDatoFiltro { Activo = true, Tipo = Entidades.Constantes.TipoMetaDato.UNIDAD_MEDIDA });

                ViewBag.UnidadMedidas = unidadMedidas;
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

        public async Task<IActionResult> Seleccionar(string callBack = "SetMaterial", bool muchos = true)
        {
            try
            {
                List<MetaDato> unidadMedidas = await _metaDatoServicio.ListarAsync(new MetaDatoFiltro { Activo = true, Tipo = Entidades.Constantes.TipoMetaDato.UNIDAD_MEDIDA });
                ViewBag.CallBack = callBack;
                ViewBag.UnidadMedidas = unidadMedidas;
                return PartialView(muchos ? "_SeleccionarMuchos" : "_SeleccionarUno");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(MaterialModel.Editar model)
        {
            try
            {
                Validar(model);
                if (ModelState.IsValid)
                {
                    bool existeCodigo = await _materialServicio.CountByAsync(x => x.Id != model.Id && x.Codigo == model.Codigo) > 0;
                    if (existeCodigo) ModelState.AddModelError("Codigo", "Ya existe un material con el código ingresado.");
                }
                if (ModelState.IsValid)
                {
                    Material entidad = model.Get();
                    await _materialServicio.ActualizarAsync(entidad);
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

        public async Task<IActionResult> Listar(MaterialFiltro filtro, int pageIndex, int pageSize)
        {
            try
            {
                List<Material> lista = await _materialServicio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
                int totalRows = await _materialServicio.ContarAsync(filtro);
                return Ok(new
                {
                    totalRows,
                    lista = lista.Select(x => new
                    {
                        x.Id,
                        x.Codigo,
                        x.CodigoPersonalizado,
                        x.Nombre,
                        x.Activo,
                        x.UnidadMedidaId,
                        x.Clasificacion,
                        UnidadMedida = new { x.UnidadMedida?.Nombre }
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
        void Validar(MaterialModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(entidad.Codigo)) ModelState.AddModelError("Codigo", "Es necesario ingresar el código.");
            if (!entidad.UnidadMedidaId.HasValue) ModelState.AddModelError("UnidadMedidaId", "Es necesario seleccionar una unidad de medida.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
        }

        [NonAction]
        void Validar(MaterialModel.Editar entidad)
        {
            ModelState.Clear();
            if (!entidad.Id.HasValue) ModelState.AddModelError("Id", "Es necesario tener un identificador.");
            if (string.IsNullOrEmpty(entidad.Codigo)) ModelState.AddModelError("Codigo", "Es necesario ingresar el código.");
            if (!entidad.UnidadMedidaId.HasValue) ModelState.AddModelError("UnidadMedidaId", "Es necesario seleccionar una unidad de medida.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
        }

        #endregion
    }
}
