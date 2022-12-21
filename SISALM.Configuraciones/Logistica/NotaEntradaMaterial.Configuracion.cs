namespace SISALM.Configuraciones.Logistica
{
    public class NotaEntradaMaterialConfiguracion
    {
        public static void Configure(EntityTypeBuilder<NotaEntradaMaterial> modelBuilder)
        {
            modelBuilder.ToTable("NotaEntradaMaterial").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.NotaEntradaId).HasColumnName("notaentradaid");
            modelBuilder.Property(x => x.AlmacenId).HasColumnName("almacenid");
            modelBuilder.Property(x => x.MaterialId).HasColumnName("materialid");

            modelBuilder.Property(x => x.Cantidad).HasColumnName("cantidad");
            modelBuilder.Property(x => x.Precio).HasColumnName("precio");

            modelBuilder.HasOne(x => x.NotaEntrada).WithMany(x => x.Materiales).IsRequired();
            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.NotasEntrada).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.NotasEntrada).IsRequired();
        }
    }
}