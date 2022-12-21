namespace SISALM.Configuraciones.General
{
    public class MaterialConfiguracion
    {
        public static void Configure(EntityTypeBuilder<Material> modelBuilder)
        {
            modelBuilder.ToTable("Material").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.Codigo).HasColumnName("codigo");
            modelBuilder.Property(x => x.CodigoPersonalizado).HasColumnName("codigopersonalizado");
            modelBuilder.Property(x => x.Clasificacion).HasColumnName("clasificacion");
            modelBuilder.Property(x => x.UnidadMedidaId).HasColumnName("unidadmedidaid");
            modelBuilder.Property(x => x.Nombre).HasColumnName("nombre");
            modelBuilder.Property(x => x.Activo).HasColumnName("activo");

            modelBuilder.Ignore(x => x.UnidadMedida);
        }
    }
}