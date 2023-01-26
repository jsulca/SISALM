using Microsoft.EntityFrameworkCore;
using SISALM.Configuraciones.General;
using SISALM.Configuraciones.Logistica;
using SISALM.Entidades.General;
using SISALM.Entidades.Logistica;

namespace SISALM.Contextos
{
    public class SISALMContexto : DbContext
    {
        #region General

        public DbSet<Material> Material { get; set; }
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<MetaDato> MetaDato { get; set; }

        #endregion

        #region Logistica

        public DbSet<NotaEntrada> NotaEntrada { get; set; }
        public DbSet<NotaEntradaMaterial> NotaEntradaMaterial { get; set; }

        public DbSet<NotaSalida> NotaSalida { get; set; }
        public DbSet<NotaSalidaMaterial> NotaSalidaMaterial { get; set; }
        public DbSet<NotaSalidaRetiro> NotaSalidaRetiro { get; set; }

        public DbSet<AlmacenMaterial> AlmacenMaterial { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }

        #endregion

        public SISALMContexto(DbContextOptions<SISALMContexto> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region General 

            MaterialConfiguracion.Configure(modelBuilder.Entity<Material>());
            AlmacenConfiguracion.Configure(modelBuilder.Entity<Almacen>());
            MetaDatoConfiguracion.Configure(modelBuilder.Entity<MetaDato>());

            #endregion

            #region Logistica

            NotaEntradaConfiguracion.Configure(modelBuilder.Entity<NotaEntrada>());
            NotaEntradaMaterialConfiguracion.Configure(modelBuilder.Entity<NotaEntradaMaterial>());
            
            NotaSalidaConfiguracion.Configure(modelBuilder.Entity<NotaSalida>());
            NotaSalidaMaterialConfiguracion.Configure(modelBuilder.Entity<NotaSalidaMaterial>());
            NotaSalidaRetiroConfiguracion.Configure(modelBuilder.Entity<NotaSalidaRetiro>());

            AlmacenMaterialConfiguracion.Configure(modelBuilder.Entity<AlmacenMaterial>());
            MovimientoConfiguracion.Configure(modelBuilder.Entity<Movimiento>());

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
