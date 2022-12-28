using SISALM.Entidades.Constantes;
namespace SISALM.Entidades.Filtros.Logistica
{
    public class NotaEntradaFiltro
    {
        public int? Id { get; set; }
        public int? NotaSalidaId { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public EstadoNotaEntrada? Estado { get; set; }
        public TipoNotaEntrada? Tipo { get; set; }
        public int? Anio { get; set; }
        public int? Mes { get; set; }
        public string? NroComprobante { get; set; }
    }
}
