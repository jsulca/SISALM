using SISALM.Entidades.Constantes;
using SISALM.Entidades.Logistica;

namespace SISALM.WebApp.Areas.Logistica.Models
{
    public struct NotaSalidaModel
    {
        public class Nuevo
        {
            public TipoNotaSalida? Tipo { get; set; }
            public EstadoNotaSalida? Estado { get; set; }
            public string? Descripcion { get; set; }

            public string? NroComprobante { get; set; }

            public List<NotaSalidaMaterial> Materiales { get; set; } = new();

            public NotaSalida Get() => new()
            {
                Tipo = Tipo!.Value,
                Estado = Estado!.Value,
                Descripcion = Descripcion!,

                NroComprobante = NroComprobante,

                Materiales = Materiales
            };
        }
    }
}
