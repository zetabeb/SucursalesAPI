using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucursalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    horarioAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gerenteSucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoMoneda = table.Column<short>(type: "smallint", nullable: false),
                    fechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaUltimaActualizacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
