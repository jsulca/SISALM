namespace SISALM.Configuraciones.Logistica
{
    public class NotaSalidaConfiguracion
    {
        public static void Configure(EntityTypeBuilder<NotaSalida> modelBuilder)
        {
            modelBuilder.ToTable("NotaSalida").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.NotaEntradaId).HasColumnName("notaentradaid");

            modelBuilder.Property(x => x.Codigo).HasColumnName("codigo");
            modelBuilder.Property(x => x.Descripcion).HasColumnName("descripcion");
            modelBuilder.Property(x => x.Estado).HasColumnName("estado");
            modelBuilder.Property(x => x.Tipo).HasColumnName("tipo");
            modelBuilder.Property(x => x.Registro).HasColumnName("registro");

            modelBuilder.Property(x => x.Anio).HasColumnName("anio");
            modelBuilder.Property(x => x.Mes).HasColumnName("mes");

            modelBuilder.Property(x => x.NroComprobante).HasColumnName("nrocomprobante");

            modelBuilder.HasOne(x => x.NotaEntrada).WithMany(x => x.NotasSalida);
        }
    }
}