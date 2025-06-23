using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectar.Migrations
{
    /// <inheritdoc />
    public partial class BorrandoTablaViaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIAJES");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VIAJES",
                columns: table => new
                {
                    idViaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empleadoid = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    rutaId = table.Column<int>(type: "int", nullable: false),
                    vehiculoId = table.Column<int>(type: "int", nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIAJES", x => x.idViaje);
                    table.ForeignKey(
                        name: "FK_VIAJES_EMPLEADOS_empleadoid",
                        column: x => x.empleadoid,
                        principalTable: "EMPLEADOS",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VIAJES_PRODUCTOS_productoId",
                        column: x => x.productoId,
                        principalTable: "PRODUCTOS",
                        principalColumn: "Idproducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VIAJES_RUTAS_rutaId",
                        column: x => x.rutaId,
                        principalTable: "RUTAS",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VIAJES_VEHICULOS_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "VEHICULOS",
                        principalColumn: "placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VIAJES_empleadoid",
                table: "VIAJES",
                column: "empleadoid");

            migrationBuilder.CreateIndex(
                name: "IX_VIAJES_productoId",
                table: "VIAJES",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_VIAJES_rutaId",
                table: "VIAJES",
                column: "rutaId");

            migrationBuilder.CreateIndex(
                name: "IX_VIAJES_vehiculoId",
                table: "VIAJES",
                column: "vehiculoId");
        }
    }
}
