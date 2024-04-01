using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucursalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRolColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rol",
                table: "Usuarios");
        }
    }
}
