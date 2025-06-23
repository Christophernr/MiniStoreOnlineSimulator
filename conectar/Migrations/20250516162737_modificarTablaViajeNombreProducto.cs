using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectar.Migrations
{
    /// <inheritdoc />
    public partial class modificarTablaViajeNombreProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "VIAJES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "VIAJES");
        }
    }
}
