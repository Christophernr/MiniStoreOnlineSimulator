using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectar.Migrations
{
    /// <inheritdoc />
    public partial class modificacionSubclases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipoLicencia",
                table: "EMPLEADOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoLicencia",
                table: "EMPLEADOS");
        }
    }
}
