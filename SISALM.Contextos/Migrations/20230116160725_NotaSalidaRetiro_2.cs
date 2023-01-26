using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISALM.Contextos.Migrations
{
    /// <inheritdoc />
    public partial class NotaSalidaRetiro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalidaRetiro_Almacen_AlmacenId",
                table: "NotaSalidaRetiro");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalidaRetiro_Material_MaterialId",
                table: "NotaSalidaRetiro");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalidaRetiro_NotaSalida_NotaSalidaId",
                table: "NotaSalidaRetiro");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "NotaSalidaRetiro",
                newName: "precio");

            migrationBuilder.RenameColumn(
                name: "Periodo",
                table: "NotaSalidaRetiro",
                newName: "periodo");

            migrationBuilder.RenameColumn(
                name: "NotaSalidaId",
                table: "NotaSalidaRetiro",
                newName: "notasalidaid");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "NotaSalidaRetiro",
                newName: "materialid");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "NotaSalidaRetiro",
                newName: "cantidad");

            migrationBuilder.RenameColumn(
                name: "AlmacenId",
                table: "NotaSalidaRetiro",
                newName: "almacenid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NotaSalidaRetiro",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_NotaSalidaRetiro_NotaSalidaId",
                table: "NotaSalidaRetiro",
                newName: "IX_NotaSalidaRetiro_notasalidaid");

            migrationBuilder.RenameIndex(
                name: "IX_NotaSalidaRetiro_MaterialId",
                table: "NotaSalidaRetiro",
                newName: "IX_NotaSalidaRetiro_materialid");

            migrationBuilder.RenameIndex(
                name: "IX_NotaSalidaRetiro_AlmacenId",
                table: "NotaSalidaRetiro",
                newName: "IX_NotaSalidaRetiro_almacenid");

            migrationBuilder.AlterColumn<decimal>(
                name: "precio",
                table: "NotaSalidaRetiro",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "cantidad",
                table: "NotaSalidaRetiro",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaSalidaRetiro_Almacen_almacenid",
                table: "NotaSalidaRetiro",
                column: "almacenid",
                principalTable: "Almacen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaSalidaRetiro_Material_materialid",
                table: "NotaSalidaRetiro",
                column: "materialid",
                principalTable: "Material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaSalidaRetiro_NotaSalida_notasalidaid",
                table: "NotaSalidaRetiro",
                column: "notasalidaid",
                principalTable: "NotaSalida",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalidaRetiro_Almacen_almacenid",
                table: "NotaSalidaRetiro");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalidaRetiro_Material_materialid",
                table: "NotaSalidaRetiro");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaSalidaRetiro_NotaSalida_notasalidaid",
                table: "NotaSalidaRetiro");

            migrationBuilder.RenameColumn(
                name: "precio",
                table: "NotaSalidaRetiro",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "periodo",
                table: "NotaSalidaRetiro",
                newName: "Periodo");

            migrationBuilder.RenameColumn(
                name: "notasalidaid",
                table: "NotaSalidaRetiro",
                newName: "NotaSalidaId");

            migrationBuilder.RenameColumn(
                name: "materialid",
                table: "NotaSalidaRetiro",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "NotaSalidaRetiro",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "almacenid",
                table: "NotaSalidaRetiro",
                newName: "AlmacenId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NotaSalidaRetiro",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_NotaSalidaRetiro_notasalidaid",
                table: "NotaSalidaRetiro",
                newName: "IX_NotaSalidaRetiro_NotaSalidaId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaSalidaRetiro_materialid",
                table: "NotaSalidaRetiro",
                newName: "IX_NotaSalidaRetiro_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaSalidaRetiro_almacenid",
                table: "NotaSalidaRetiro",
                newName: "IX_NotaSalidaRetiro_AlmacenId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "NotaSalidaRetiro",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "NotaSalidaRetiro",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaSalidaRetiro_Almacen_AlmacenId",
                table: "NotaSalidaRetiro",
                column: "AlmacenId",
                principalTable: "Almacen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaSalidaRetiro_Material_MaterialId",
                table: "NotaSalidaRetiro",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaSalidaRetiro_NotaSalida_NotaSalidaId",
                table: "NotaSalidaRetiro",
                column: "NotaSalidaId",
                principalTable: "NotaSalida",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
