using SISALM.Entidades.General;

namespace SISALM.Entidades.Logistica
{
    public partial class AlmacenMaterial
    {
        public int Id { get; set; }
        public int AlmacenId { get; set; }
        public int MaterialId { get; set; }

        public DateTime? Periodo { get; set; }

        public decimal Cantidad { get; set; }
        public decimal Reservado { get; set; }
        
        public decimal Precio { get; set; }

        public Almacen? Almacen { get; set; }
        public Material? Material { get; set; }
    }
}
