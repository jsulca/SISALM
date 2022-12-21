namespace SISALM.Configuraciones.Logistica
{
    public class MovimientoConfiguracion
    {
        public static void Configure(EntityTypeBuilder<Movimiento> modelBuilder)
        {
            modelBuilder.ToTable("Movimiento").HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.AlmacenId).HasColumnName("almacenid");
            modelBuilder.Property(x => x.MaterialId).HasColumnName("materialid");

            modelBuilder.Property(x => x.NotaEntradaId).HasColumnName("notaentradaid");
            modelBuilder.Property(x => x.NotaSalidaId).HasColumnName("notasalidaid");
            modelBuilder.Property(x => x.Registro).HasColumnName("registro");

            modelBuilder.Property(x => x.InicialCantidad).HasColumnName("inicialcantidad");
            modelBuilder.Property(x => x.InicialPrecio).HasColumnName("inicialprecio");

            modelBuilder.Property(x => x.EntradaCantidad).HasColumnName("entradacantidad");
            modelBuilder.Property(x => x.EntradaPrecio).HasColumnName("entradaprecio");

            modelBuilder.Property(x => x.SalidaCantidad).HasColumnName("salidacantidad");
            modelBuilder.Property(x => x.SalidaPrecio).HasColumnName("salidaprecio");

            modelBuilder.Property(x => x.FinalCantidad).HasColumnName("finalcantidad");
            modelBuilder.Property(x => x.FinalPrecio).HasColumnName("finalprecio");


            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.Movimientos).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.Movimientos).IsRequired();

            modelBuilder.HasOne(x => x.NotaEntrada).WithMany(x => x.Movimientos);
            modelBuilder.HasOne(x => x.NotaSalida).WithMany(x => x.Movimientos);
        }
    }
}