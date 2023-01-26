using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SISALM.Contextos.Migrations
{
    /// <inheritdoc />
    public partial class NotaSalidaRetiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaSalidaRetiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotaSalidaId = table.Column<int>(type: "integer", nullable: false),
                    AlmacenId = table.Column<int>(type: "integer", nullable: false),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    Periodo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaSalidaRetiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaSalidaRetiro_Almacen_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaSalidaRetiro_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaSalidaRetiro_NotaSalida_NotaSalidaId",
                        column: x => x.NotaSalidaId,
                        principalTable: "NotaSalida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalidaRetiro_AlmacenId",
                table: "NotaSalidaRetiro",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalidaRetiro_MaterialId",
                table: "NotaSalidaRetiro",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSalidaRetiro_NotaSalidaId",
                table: "NotaSalidaRetiro",
                column: "NotaSalidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaSalidaRetiro");
        }
    }
}
