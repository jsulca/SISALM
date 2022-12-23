using SISALM.Entidades.Constantes;
using SISALM.Entidades.General;

namespace SISALM.WebApp.Areas.General.Models
{
    public struct MaterialModel
    {
        public class Nuevo
        {
            public string? Codigo { get; set; }
            public string? CodigoPersonalizado { get; set; }
            public ClasificacionMaterial? Clasificacion { get; set; }
            public int? UnidadMedidaId { get; set; }
            public string? Nombre { get; set; }
            public bool Activo { get; set; }

            public Material Get() => new()
            {
                Codigo = Codigo!,
                CodigoPersonalizado = CodigoPersonalizado,
                Clasificacion = Clasificacion,
                UnidadMedidaId = UnidadMedidaId!.Value,

                Nombre = Nombre!,
                Activo = Activo
            };
        }

        public class Editar
        {
            public int? Id { get; set; }
            public string? Codigo { get; set; }
            public string? CodigoPersonalizado { get; set; }
            public ClasificacionMaterial? Clasificacion { get; set; }
            public int? UnidadMedidaId { get; set; }
            public string? Nombre { get; set; }
            public bool Activo { get; set; }

            public Material Get() => new()
            {
                Id = Id!.Value,
                Codigo = Codigo!,
                CodigoPersonalizado = CodigoPersonalizado,
                Clasificacion = Clasificacion,
                UnidadMedidaId = UnidadMedidaId!.Value,

                Nombre = Nombre!,
                Activo = Activo
            };
        }
    }
}
