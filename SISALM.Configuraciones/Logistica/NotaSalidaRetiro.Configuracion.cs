namespace SISALM.Configuraciones.Logistica
{
    public class NotaSalidaRetiroConfiguracion
    {
        public static void Configure(EntityTypeBuilder<NotaSalidaRetiro> modelBuilder)
        {
            modelBuilder.ToTable("NotaSalidaRetiro").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.NotaSalidaId).HasColumnName("notasalidaid");
            modelBuilder.Property(x => x.AlmacenId).HasColumnName("almacenid");
            modelBuilder.Property(x => x.MaterialId).HasColumnName("materialid");

            modelBuilder.Property(x => x.Cantidad).HasColumnName("cantidad").HasPrecision(18, 2);
            modelBuilder.Property(x => x.Precio).HasColumnName("precio").HasPrecision(18, 2);
            modelBuilder.Property(x => x.Periodo).HasColumnName("periodo");

            modelBuilder.HasOne(x => x.NotaSalida).WithMany(x => x.Retiros).IsRequired();
            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.Retiros).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.Retiros).IsRequired();
        }
    }
}