using SISALM.Entidades.Constantes;
namespace SISALM.Entidades.Filtros.Logistica
{
    public class NotaSalidaFiltro
    {
        public int? Id { get; set; }
        public int? NotaEntradaId { get; set; }

        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public EstadoNotaSalida? Estado { get; set; }
        public TipoNotaSalida? Tipo { get; set; }

        public int? Anio { get; set; }
        public int? Mes { get; set; }
        public string? NroComprobante { get; set; }
    }
}
