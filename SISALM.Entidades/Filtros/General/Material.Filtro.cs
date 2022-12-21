using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.Filtros.General
{
    public class MaterialFiltro
    {
        public string? Codigo { get; set; }
        public string? CodigoPersonalizado { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }

        public ClasificacionMaterial? Clasificacion { get; set; }
        public int? UnidadMedidaId { get; set; }
    }
}
