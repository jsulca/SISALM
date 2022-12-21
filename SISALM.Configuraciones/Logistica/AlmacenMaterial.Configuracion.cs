namespace SISALM.Configuraciones.Logistica
{
    public class AlmacenMaterialConfiguracion
    {
        public static void Configure(EntityTypeBuilder<AlmacenMaterial> modelBuilder)
        {
            modelBuilder.ToTable("AlmacenMaterial").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.AlmacenId).HasColumnName("almacenid");
            modelBuilder.Property(x => x.MaterialId).HasColumnName("materialid");
            modelBuilder.Property(x => x.Periodo).HasColumnName("periodo");
            modelBuilder.Property(x => x.Cantidad).HasColumnName("cantidad");
            modelBuilder.Property(x => x.Reservado).HasColumnName("reservado");
            modelBuilder.Property(x => x.Precio).HasColumnName("precio");

            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.Materiales).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.Almacenes).IsRequired();
        }
    }
}