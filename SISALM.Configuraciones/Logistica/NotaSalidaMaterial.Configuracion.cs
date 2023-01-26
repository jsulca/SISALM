namespace SISALM.Configuraciones.Logistica
{
    public class NotaSalidaMaterialConfiguracion
    {
        public static void Configure(EntityTypeBuilder<NotaSalidaMaterial> modelBuilder)
        {
            modelBuilder.ToTable("NotaSalidaMaterial").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.NotaSalidaId).HasColumnName("notasalidaid");
            modelBuilder.Property(x => x.AlmacenId).HasColumnName("almacenid");
            modelBuilder.Property(x => x.MaterialId).HasColumnName("materialid");

            modelBuilder.Property(x => x.Cantidad).HasColumnName("cantidad").HasPrecision(18, 2);
            //modelBuilder.Property(x => x.Precio).HasColumnName("precio").HasPrecision(18, 2);

            modelBuilder.HasOne(x => x.NotaSalida).WithMany(x => x.Materiales).IsRequired();
            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.NotasSalida).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.NotasSalida).IsRequired();
        }
    }
}