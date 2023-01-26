using SISALM.Entidades.Constantes;
using SISALM.Entidades.Logistica;

namespace SISALM.Entidades.General
{
    public partial class Material
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string? CodigoPersonalizado { get; set; }
        public ClasificacionMaterial? Clasificacion { get; set; }
        public int UnidadMedidaId { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public List<AlmacenMaterial>? Almacenes { get; set; }
        public List<Movimiento>? Movimientos { get; set; }
        public List<NotaEntradaMaterial>? NotasEntrada { get; set; }
        public List<NotaSalidaMaterial>? NotasSalida { get; set; }

        public List<NotaSalidaRetiro>? Retiros { get; set; }
    }
}
