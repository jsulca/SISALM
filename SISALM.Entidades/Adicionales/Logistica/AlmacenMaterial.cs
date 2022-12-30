namespace SISALM.Entidades.Logistica
{
    public partial class AlmacenMaterial
    {
        public decimal PrecioTotal { get => Precio * Cantidad; }
        public decimal Existencia { get => Cantidad + Reservado; }
    }
}
