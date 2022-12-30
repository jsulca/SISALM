namespace SISALM.Entidades.Logistica
{
    public partial class NotaEntradaMaterial
    {
        public decimal PrecioTotal { get => Precio * Cantidad; }
    }
}
