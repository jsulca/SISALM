using SISALM.Entidades.Constantes;
using SISALM.Entidades.Logistica;

namespace SISALM.Entidades.General
{
    public partial class Almacen
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public TipoAlmacen Tipo { get; set; }
        public DateTime Registro { get; set; }
        public string? Direccion { get; set; }

        public List<AlmacenMaterial>? Materiales { get; set; }
        public List<Movimiento>? Movimientos { get; set; }

        public List<NotaEntradaMaterial>? NotasEntrada { get; set; }
        public List<NotaSalidaMaterial>? NotasSalida { get; set; }
    }
}
