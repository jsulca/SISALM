namespace SISALM.WebApp.Models
{
    public class PersonaModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime Nacimiento { get; set; }
    }
}
