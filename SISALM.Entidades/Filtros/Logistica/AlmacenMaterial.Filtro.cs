using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.Filtros.Logistica
{
    public class AlmacenMaterialFiltro
    {
        public string? MaterialCodigo { get; set; }
        public string? MaterialNombre { get; set; }
        public int? MaterialUnidadMedidaId { get; set; }
        public string? AlmacenCodigo { get; set; }
        public string? AlmacenNombre { get; set; }
        public TipoAlmacen? AlmacenTipo { get; set; }
    }
}
