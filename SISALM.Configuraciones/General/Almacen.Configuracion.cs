namespace SISALM.Configuraciones.General
{
    public class AlmacenConfiguracion
    {
        public static void Configure(EntityTypeBuilder<Almacen> modelBuilder)
        {
            modelBuilder.ToTable("Almacen").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.Codigo).HasColumnName("codigo");
            modelBuilder.Property(x => x.Nombre).HasColumnName("nombre");
            modelBuilder.Property(x => x.Activo).HasColumnName("activo");

            modelBuilder.Property(x => x.Tipo).HasColumnName("tipo");
            modelBuilder.Property(x => x.Registro).HasColumnName("registro");
            modelBuilder.Property(x => x.Direccion).HasColumnName("direccion");
        }
    }
}