using SISALM.Entidades.Constantes;
using SISALM.Entidades.General;

namespace SISALM.WebApp.Areas.General.Models
{
    public struct MetaDatoModel
    {
        public class Nuevo
        {
            public TipoMetaDato? Tipo { get; set; }
            public string? Codigo { get; set; }
            public string? Nombre { get; set; } 
            public bool Activo { get; set; }

            public MetaDato Get() => new()
            {
                Codigo = Codigo,
                Nombre = Nombre!,
                Tipo = Tipo!.Value,
                Activo = Activo
            };
        }

        public class Editar
        {
            public int? Id { get; set; }
            public string? Codigo { get; set; }
            public string? Nombre { get; set; }
            public bool Activo { get; set; }

            public MetaDato Get() => new()
            {
                Id = Id!.Value,
                Codigo = Codigo,
                Nombre = Nombre!,
                Activo = Activo
            };
        }
    }
}
