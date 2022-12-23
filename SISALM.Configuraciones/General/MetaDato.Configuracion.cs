namespace SISALM.Configuraciones.General
{
    public class MetaDatoConfiguracion
    {
        public static void Configure(EntityTypeBuilder<MetaDato> modelBuilder)
        {
            modelBuilder.ToTable("MetaDato").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.Tipo).HasColumnName("tipo");
            modelBuilder.Property(x => x.Codigo).HasColumnName("codigo");
            modelBuilder.Property(x => x.Nombre).HasColumnName("nombre");
            modelBuilder.Property(x => x.Activo).HasColumnName("activo");
        }
    }
}