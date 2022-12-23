using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.Logistica
{
    public partial class NotaEntrada
    {
        public int Id { get; set; }
        public int? NotaSalidaId { get; set; }

        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public EstadoNotaEntrada Estado { get; set; }
        public TipoNotaEntrada Tipo { get; set; }
        public DateTime Registro { get; set; }

        public int Anio { get; set; }
        public int Mes { get; set; }

        public DateTime FechaEntrega { get; set; }
        public string? NroComprobante { get; set; }

        public NotaSalida? NotaSalida { get; set; }

        public List<NotaSalida>? NotasSalida { get; set; }
        public List<Movimiento>? Movimientos { get; set; }
        public List<NotaEntradaMaterial>? Materiales { get; set; }
    }
}
