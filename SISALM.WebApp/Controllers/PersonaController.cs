using Microsoft.AspNetCore.Mvc;
using SISALM.WebApp.Models;

namespace SISALM.WebApp.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
          public IActionResult Index02()
        {
            return Ok(new
            {
                mensaje="new"
            });
        }

        public IActionResult Nuevo()
        {
            string mensaje = "Prospecto";
            ViewBag.Mensaje = mensaje;

            PersonaModel model = new() 
            {
              Nombre = "Junior",
                //Apellido = "Sulca",
                Activo = true,
                Nacimiento = DateTime.Today
            };
            return View(model);
        }

    }
}
