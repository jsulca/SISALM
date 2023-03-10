// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SISALM.Contextos;

#nullable disable

namespace SISALM.Contextos.Migrations
{
    [DbContext(typeof(SISALMContexto))]
    [Migration("20221222145652_Modificacion_MetaDato")]
    partial class ModificacionMetaDato
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SISALM.Entidades.General.Almacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean")
                        .HasColumnName("activo");

                    b.Property<string>("Codigo")
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<string>("Direccion")
                        .HasColumnType("text")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registro");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("Almacen", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.General.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean")
                        .HasColumnName("activo");

                    b.Property<int?>("Clasificacion")
                        .HasColumnType("integer")
                        .HasColumnName("clasificacion");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<string>("CodigoPersonalizado")
                        .HasColumnType("text")
                        .HasColumnName("codigopersonalizado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<int>("UnidadMedidaId")
                        .HasColumnType("integer")
                        .HasColumnName("unidadmedidaid");

                    b.HasKey("Id");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.General.MetaDato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean")
                        .HasColumnName("activo");

                    b.Property<string>("Codigo")
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("MetaDato", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.AlmacenMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlmacenId")
                        .HasColumnType("integer")
                        .HasColumnName("almacenid");

                    b.Property<decimal>("Cantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("cantidad");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("materialid");

                    b.Property<DateTime?>("Periodo")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("periodo");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("precio");

                    b.Property<decimal>("Reservado")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("reservado");

                    b.HasKey("Id");

                    b.HasIndex("AlmacenId");

                    b.HasIndex("MaterialId");

                    b.ToTable("AlmacenMaterial", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlmacenId")
                        .HasColumnType("integer")
                        .HasColumnName("almacenid");

                    b.Property<decimal>("EntradaCantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("entradacantidad");

                    b.Property<decimal>("EntradaPrecio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("entradaprecio");

                    b.Property<decimal>("FinalCantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("finalcantidad");

                    b.Property<decimal>("FinalPrecio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("finalprecio");

                    b.Property<decimal>("InicialCantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("inicialcantidad");

                    b.Property<decimal>("InicialPrecio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("inicialprecio");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("materialid");

                    b.Property<int?>("NotaEntradaId")
                        .HasColumnType("integer")
                        .HasColumnName("notaentradaid");

                    b.Property<int?>("NotaSalidaId")
                        .HasColumnType("integer")
                        .HasColumnName("notasalidaid");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registro");

                    b.Property<decimal>("SalidaCantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("salidacantidad");

                    b.Property<decimal>("SalidaPrecio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("salidaprecio");

                    b.HasKey("Id");

                    b.HasIndex("AlmacenId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("NotaEntradaId");

                    b.HasIndex("NotaSalidaId");

                    b.ToTable("Movimiento", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaEntrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("integer")
                        .HasColumnName("anio");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<int>("Estado")
                        .HasColumnType("integer")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fechaentrega");

                    b.Property<int>("Mes")
                        .HasColumnType("integer")
                        .HasColumnName("mes");

                    b.Property<int?>("NotaSalidaId")
                        .HasColumnType("integer")
                        .HasColumnName("notasalidaid");

                    b.Property<string>("NroComprobante")
                        .HasColumnType("text")
                        .HasColumnName("nrocomprobante");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registro");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("NotaSalidaId");

                    b.ToTable("NotaEntrada", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaEntradaMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlmacenId")
                        .HasColumnType("integer")
                        .HasColumnName("almacenid");

                    b.Property<decimal>("Cantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("cantidad");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("materialid");

                    b.Property<int>("NotaEntradaId")
                        .HasColumnType("integer")
                        .HasColumnName("notaentradaid");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("AlmacenId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("NotaEntradaId");

                    b.ToTable("NotaEntradaMaterial", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaSalida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("integer")
                        .HasColumnName("anio");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<int>("Estado")
                        .HasColumnType("integer")
                        .HasColumnName("estado");

                    b.Property<int>("Mes")
                        .HasColumnType("integer")
                        .HasColumnName("mes");

                    b.Property<int?>("NotaEntradaId")
                        .HasColumnType("integer")
                        .HasColumnName("notaentradaid");

                    b.Property<string>("NroComprobante")
                        .HasColumnType("text")
                        .HasColumnName("nrocomprobante");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registro");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("NotaEntradaId");

                    b.ToTable("NotaSalida", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaSalidaMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlmacenId")
                        .HasColumnType("integer")
                        .HasColumnName("almacenid");

                    b.Property<decimal>("Cantidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("cantidad");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("materialid");

                    b.Property<int>("NotaSalidaId")
                        .HasColumnType("integer")
                        .HasColumnName("notasalidaid");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("AlmacenId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("NotaSalidaId");

                    b.ToTable("NotaSalidaMaterial", (string)null);
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.AlmacenMaterial", b =>
                {
                    b.HasOne("SISALM.Entidades.General.Almacen", "Almacen")
                        .WithMany("Materiales")
                        .HasForeignKey("AlmacenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.General.Material", "Material")
                        .WithMany("Almacenes")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Almacen");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.Movimiento", b =>
                {
                    b.HasOne("SISALM.Entidades.General.Almacen", "Almacen")
                        .WithMany("Movimientos")
                        .HasForeignKey("AlmacenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.General.Material", "Material")
                        .WithMany("Movimientos")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.Logistica.NotaEntrada", "NotaEntrada")
                        .WithMany("Movimientos")
                        .HasForeignKey("NotaEntradaId");

                    b.HasOne("SISALM.Entidades.Logistica.NotaSalida", "NotaSalida")
                        .WithMany("Movimientos")
                        .HasForeignKey("NotaSalidaId");

                    b.Navigation("Almacen");

                    b.Navigation("Material");

                    b.Navigation("NotaEntrada");

                    b.Navigation("NotaSalida");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaEntrada", b =>
                {
                    b.HasOne("SISALM.Entidades.Logistica.NotaSalida", "NotaSalida")
                        .WithMany("NotasEntrada")
                        .HasForeignKey("NotaSalidaId");

                    b.Navigation("NotaSalida");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaEntradaMaterial", b =>
                {
                    b.HasOne("SISALM.Entidades.General.Almacen", "Almacen")
                        .WithMany("NotasEntrada")
                        .HasForeignKey("AlmacenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.General.Material", "Material")
                        .WithMany("NotasEntrada")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.Logistica.NotaEntrada", "NotaEntrada")
                        .WithMany("Materiales")
                        .HasForeignKey("NotaEntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Almacen");

                    b.Navigation("Material");

                    b.Navigation("NotaEntrada");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaSalida", b =>
                {
                    b.HasOne("SISALM.Entidades.Logistica.NotaEntrada", "NotaEntrada")
                        .WithMany("NotasSalida")
                        .HasForeignKey("NotaEntradaId");

                    b.Navigation("NotaEntrada");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaSalidaMaterial", b =>
                {
                    b.HasOne("SISALM.Entidades.General.Almacen", "Almacen")
                        .WithMany("NotasSalida")
                        .HasForeignKey("AlmacenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.General.Material", "Material")
                        .WithMany("NotasSalida")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISALM.Entidades.Logistica.NotaSalida", "NotaSalida")
                        .WithMany("Materiales")
                        .HasForeignKey("NotaSalidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Almacen");

                    b.Navigation("Material");

                    b.Navigation("NotaSalida");
                });

            modelBuilder.Entity("SISALM.Entidades.General.Almacen", b =>
                {
                    b.Navigation("Materiales");

                    b.Navigation("Movimientos");

                    b.Navigation("NotasEntrada");

                    b.Navigation("NotasSalida");
                });

            modelBuilder.Entity("SISALM.Entidades.General.Material", b =>
                {
                    b.Navigation("Almacenes");

                    b.Navigation("Movimientos");

                    b.Navigation("NotasEntrada");

                    b.Navigation("NotasSalida");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaEntrada", b =>
                {
                    b.Navigation("Materiales");

                    b.Navigation("Movimientos");

                    b.Navigation("NotasSalida");
                });

            modelBuilder.Entity("SISALM.Entidades.Logistica.NotaSalida", b =>
                {
                    b.Navigation("Materiales");

                    b.Navigation("Movimientos");

                    b.Navigation("NotasEntrada");
                });
#pragma warning restore 612, 618
        }
    }
}
