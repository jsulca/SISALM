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
            //modelBuilder.Property(x => x.Periodo).HasColumnName("periodo").HasColumnType("date");
            modelBuilder.Property(x => x.Periodo).HasColumnName("periodo");
            modelBuilder.Property(x => x.Cantidad).HasColumnName("cantidad").HasPrecision(18, 2);
            modelBuilder.Property(x => x.Reservado).HasColumnName("reservado").HasPrecision(18, 2);
            modelBuilder.Property(x => x.Precio).HasColumnName("precio").HasPrecision(18, 2);

            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.Materiales).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.Almacenes).IsRequired();
        }
    }
}