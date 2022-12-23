using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.Filtros.General
{
    public class MetaDatoFiltro
    {
        public TipoMetaDato? Tipo { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }

        public TipoMetaDato[]? Tipos { get; set; }
    }
}
