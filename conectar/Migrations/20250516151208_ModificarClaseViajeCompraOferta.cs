using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectar.Migrations
{
    /// <inheritdoc />
    public partial class ModificarClaseViajeCompraOferta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "compraOferta",
                table: "VIAJES",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "compraOferta",
                table: "VIAJES");
        }
    }
}
