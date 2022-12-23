using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SISALM.Contextos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    direccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "text", nullable: false),
                    codigopersonalizado = table.Column<string>(type: "text", nullable: true),
                    clasificacion = table.Column<int>(type: "integer", nullable: true),
                    unidadmedidaid = table.Column<int>(type: "integer", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MetaDato",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlmacenMaterial",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    almacenid = table.Column<int>(type: "integer", nullable: false),
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    periodo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    reservado = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    precio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlmacenMaterial", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlmacenMaterial_Almacen_almacenid",
                        column: x => x.almacenid,
                        principalTable: "Almacen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlmacenMaterial_Material_materialid",
                        column: x => x.materialid,
                        principalTable: "Material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    almacenid = table.Column<int>(type: "integer", nullable: false),
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    notaentradaid = table.Column<int>(type: "integer", nullable: true),
                    notasalidaid = table.Column<int>(type: "integer", nullable: true),
                    registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    inicialcantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inicialprecio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    entradacantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    entradaprecio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    salidacantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    salidaprecio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    finalcantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    finalprecio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Almacen_almacenid",
                        column: x => x.almacenid,
                        principalTable: "Almacen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimiento_Material_materialid",
                        column: x => x.materialid,
                        principalTable: "Material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaEntrada",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notasalidaid = table.Column<int>(type: "integer", nullable: true),
                    codigo = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    anio = table.Column<int>(type: "integer", nullable: false),
                    mes = table.Column<int>(type: "integer", nullable: false),
                    fechaentrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nrocomprobante = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaEntrada", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NotaEntradaMaterial",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notaentradaid = table.Column<int>(type: "integer", nullable: false),
                    almacenid = table.Column<int>(type: "integer", nullable: false),
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    cantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    precio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaEntradaMaterial", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotaEntradaMaterial_Almacen_almacenid",
                        column: x => x.almacenid,
                        principalTable: "Almacen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaEntradaMaterial_Material_materialid",
                        column: x => x.materialid,
                        principalTable: "Material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaEntradaMaterial_NotaEntrada_notaentradaid",
                        column: x => x.notaentradaid,
                        principalTable: "NotaEntrada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaSalida",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notaentradaid = table.Column<int>(type: "integer", nullable: true),
                    codigo = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    anio = table.Column<int>(type: "integer", nullable: false),
                    mes = table.Column<int>(type: "integer", nullable: false),
                    nrocomprobante = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaSalida", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotaSalida_NotaEntrada_notaentradaid",
                        column: x => x.notaentradaid,
                        principalTable: "NotaEntrada",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NotaSalidaMaterial",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notasalidaid = table.Column<int>(type: "integer", nullable: false),
                    almacenid = table.Column<int>(type: "integer", nullable: false),
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    cantidad = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    precio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaSalidaMaterial", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotaSalidaMaterial_Almacen_almacenid",
                        column: x => x.almacenid,
                        principalTable: "Almacen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaSalidaMaterial_Material_materialid",
                        column: x => x.materialid,
                        principalTable: "Material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaSalidaMaterial_NotaSalida_notasalidaid",
                        column: x => x.notasalidaid,
                        principalTable: "NotaSalida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlmacenMaterial_almacenid",
                table: "AlmacenMaterial",
                column: "almacenid");

            migrationBuilder.CreateIndex(
                name: "IX_AlmacenMaterial_materialid",
                table: "AlmacenMaterial",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_almacenid",
                table: "Movimiento",
                column: "almacenid");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_materialid",
                table: "Movimiento",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_notaentradaid",
                table: "Movimiento",
                column: "notaentradaid");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_notasalidaid",
                table: "Movimiento",
                column: "notasalidaid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaEntrada_notasalidaid",
                table: "NotaEntrada",
                column: "notasalidaid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaEntradaMaterial_almacenid",
                table: "NotaEntradaMaterial",
                column: "almacenid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaEntradaMaterial_materialid",
                table: "NotaEntradaMaterial",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaEntradaMaterial_notaentradaid",
                table: "NotaEntradaMaterial",
                column: "notaentradaid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalida_notaentradaid",
                table: "NotaSalida",
                column: "notaentradaid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalidaMaterial_almacenid",
                table: "NotaSalidaMaterial",
                column: "almacenid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalidaMaterial_materialid",
                table: "NotaSalidaMaterial",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalidaMaterial_notasalidaid",
                table: "NotaSalidaMaterial",
                column: "notasalidaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimiento_NotaEntrada_notaentradaid",
                table: "Movimiento",
                column: "notaentradaid",
                principalTable: "NotaEntrada",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimiento_NotaSalida_notasalidaid",
                table: "Movimiento",
                column: "notasalidaid",
                principalTable: "NotaSalida",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaEntrada_NotaSalida_notasalidaid",
                table: "NotaEntrada",
                column: "notasalidaid",
                principalTable: "NotaSalida",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalida_NotaEntrada_notaentradaid",
                table: "NotaSalida");

            migrationBuilder.DropTable(
                name: "AlmacenMaterial");

            migrationBuilder.DropTable(
                name: "MetaDato");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "NotaEntradaMaterial");

            migrationBuilder.DropTable(
                name: "NotaSalidaMaterial");

            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "NotaEntrada");

            migrationBuilder.DropTable(
                name: "NotaSalida");
        }
    }
}
