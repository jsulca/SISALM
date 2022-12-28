using SISALM.Entidades.Constantes;
using SISALM.Entidades.Logistica;

namespace SISALM.WebApp.Areas.Logistica.Models
{
    public struct NotaEntradaModel
    {
         public class Nuevo
        {
            public TipoNotaEntrada? Tipo { get; set; }
            public string? Descripcion { get; set; }
            public string? NroComprobante { get; set; }
            public DateTime? FechaEntrega { get; set; }

            public List<NotaEntradaMaterial> Materiales { get; set; } = new();

            public NotaEntrada Get() => new()
            {
                Tipo = Tipo!.Value,
                Descripcion = Descripcion!,
                FechaEntrega = FechaEntrega!.Value,

                NroComprobante = NroComprobante,

                Materiales = Materiales
            };
        }
    }
}
