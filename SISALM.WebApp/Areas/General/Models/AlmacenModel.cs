using SISALM.Entidades.Constantes;
using SISALM.Entidades.General;

namespace SISALM.WebApp.Areas.General.Models
{
    public struct AlmacenModel
    {
        public class Nuevo
        {
            public string? Codigo { get; set; }
            public string? Nombre { get; set; }
            public TipoAlmacen? Tipo { get; set; }
            public string? Direccion { get; set; }
            public bool Activo { get; set; }

            public Almacen Get() => new()
            {
                Codigo = Codigo,
                Nombre = Nombre!,
                Tipo = Tipo!.Value,
                Direccion = Direccion,
                Activo = Activo
            };
        }

        public class Editar
        {
            public int? Id { get; set; }
            public string? Codigo { get; set; }
            public string? Nombre { get; set; }
            public string? Direccion { get; set; }
            public bool Activo { get; set; }

            public Almacen Get() => new()
            {
                Id = Id!.Value,
                Codigo = Codigo,
                Nombre = Nombre!,
                Direccion = Direccion,
                Activo = Activo
            };
        }
    }
}
