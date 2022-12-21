using SISALM.Entidades.General;

namespace SISALM.Entidades.Logistica
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public int AlmacenId { get; set; }
        public int MaterialId { get; set; }

        public int? NotaEntradaId { get; set; }
        public int? NotaSalidaId { get; set; }

        public DateTime Registro { get; set; }

        public decimal InicialCantidad { get; set; }
        public decimal InicialPrecio { get; set; }

        public decimal EntradaCantidad { get; set; }
        public decimal EntradaPrecio { get; set; }

        public decimal SalidaCantidad { get; set; }
        public decimal SalidaPrecio { get; set; }

        public decimal FinalCantidad { get; set; }
        public decimal FinalPrecio { get; set; }

        public Almacen? Almacen { get; set; }
        public Material? Material { get; set; }
        public NotaEntrada? NotaEntrada { get; set; }
        public NotaSalida? NotaSalida { get; set; }
    }
}
