using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.Filtros.General
{
    public class AlmacenFiltro
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }

        public TipoAlmacen? Tipo { get; set; }
        public string? Direccion { get; set; }
    }
}
