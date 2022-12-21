namespace SISALM.Configuraciones.Logistica
{
    public class NotaEntradaConfiguracion
    {
        public static void Configure(EntityTypeBuilder<NotaEntrada> modelBuilder)
        {
            modelBuilder.ToTable("NotaEntrada").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.NotaSalidaId).HasColumnName("notasalidaid");

            modelBuilder.Property(x => x.Codigo).HasColumnName("codigo");
            modelBuilder.Property(x => x.Descripcion).HasColumnName("descripcion");
            modelBuilder.Property(x => x.Estado).HasColumnName("estado");
            modelBuilder.Property(x => x.Tipo).HasColumnName("tipo");
            modelBuilder.Property(x => x.Registro).HasColumnName("registro");

            modelBuilder.Property(x => x.Anio).HasColumnName("anio");
            modelBuilder.Property(x => x.Mes).HasColumnName("mes");

            modelBuilder.Property(x => x.FechaEntrega).HasColumnName("fechaentrega");
            modelBuilder.Property(x => x.NroComprobante).HasColumnName("nrocomprobante");

            modelBuilder.HasOne(x => x.NotaSalida).WithMany(x => x.NotasEntrada);
        }
    }
}