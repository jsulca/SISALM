using SISALM.Entidades.General;

namespace SISALM.Entidades.Logistica
{
    public partial class NotaSalidaMaterial
    {
        public int Id { get; set; }
        public int NotaSalidaId { get; set; }
        public int AlmacenId { get; set; }
        public int MaterialId { get; set; }

        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public NotaSalida? NotaSalida { get; set; }
        public Material? Material { get; set; }
        public Almacen? Almacen { get; set; }
    }
}
