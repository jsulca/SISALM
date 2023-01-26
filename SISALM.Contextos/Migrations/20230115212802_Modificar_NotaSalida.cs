using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISALM.Contextos.Migrations
{
    /// <inheritdoc />
    public partial class ModificarNotaSalida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "precio",
                table: "NotaSalidaMaterial");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaentrega",
                table: "NotaEntrada",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "precio",
                table: "NotaSalidaMaterial",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaentrega",
                table: "NotaEntrada",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
