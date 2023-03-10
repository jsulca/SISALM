using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.General
{
    public partial class MetaDato
    {
        public int Id { get; set; }
        public TipoMetaDato Tipo { get; set; }
        public string? Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
