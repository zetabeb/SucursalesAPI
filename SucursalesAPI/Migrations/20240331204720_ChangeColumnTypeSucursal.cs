using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucursalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnTypeSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "gerenteSucursal",
                table: "Sucursales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gerenteSucursal",
                table: "Sucursales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
