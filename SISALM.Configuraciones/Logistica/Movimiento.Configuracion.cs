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

            modelBuilder.Property(x => x.InicialCantidad).HasColumnName("inicialcantidad").HasPrecision(18, 2);
            modelBuilder.Property(x => x.InicialPrecio).HasColumnName("inicialprecio").HasPrecision(18, 2);

            modelBuilder.Property(x => x.EntradaCantidad).HasColumnName("entradacantidad").HasPrecision(18, 2);
            modelBuilder.Property(x => x.EntradaPrecio).HasColumnName("entradaprecio").HasPrecision(18, 2);

            modelBuilder.Property(x => x.SalidaCantidad).HasColumnName("salidacantidad").HasPrecision(18, 2);
            modelBuilder.Property(x => x.SalidaPrecio).HasColumnName("salidaprecio").HasPrecision(18, 2);

            modelBuilder.Property(x => x.FinalCantidad).HasColumnName("finalcantidad").HasPrecision(18, 2);
            modelBuilder.Property(x => x.FinalPrecio).HasColumnName("finalprecio").HasPrecision(18, 2);


            modelBuilder.HasOne(x => x.Almacen).WithMany(x => x.Movimientos).IsRequired();
            modelBuilder.HasOne(x => x.Material).WithMany(x => x.Movimientos).IsRequired();

            modelBuilder.HasOne(x => x.NotaEntrada).WithMany(x => x.Movimientos);
            modelBuilder.HasOne(x => x.NotaSalida).WithMany(x => x.Movimientos);
        }
    }
}