using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SISALM.WebApp.Commons.Filtros
{
    public class ModuloLogisticaFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Controller is Controller controlador) controlador.ViewBag.Modulo = Modulo.LOGISTICA;
            base.OnActionExecuted(context);
        }
    }
}
