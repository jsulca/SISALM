using SISALM.Entidades.Constantes;

namespace SISALM.Entidades.Logistica
{
    public partial class NotaSalida
    {
        public int Id { get; set; }
        public int? NotaEntradaId { get; set; }

        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public EstadoNotaSalida Estado { get; set; }
        public TipoNotaSalida Tipo { get; set; }
        public DateTime Registro { get; set; }

        public int Anio { get; set; }
        public int Mes { get; set; }

        public string? NroComprobante { get; set; }

        public NotaEntrada? NotaEntrada { get; set; }

        public List<NotaEntrada>? NotasEntrada { get; set; }
        public List<Movimiento>? Movimientos { get; set; }
        public List<NotaSalidaMaterial>? Materiales { get; set; }
    }
}
