using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SISALM.WebApp.Commons.Filtros
{
    public class ModuloGeneralFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Controller is Controller controlador) controlador.ViewBag.Modulo = Modulo.GENERAL;
            base.OnActionExecuted(context);
        }
    }
}
