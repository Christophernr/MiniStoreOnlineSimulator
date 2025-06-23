using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectar.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLEADOS",
                columns: table => new
                {
                    idEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salario = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    eficienciaBono = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    reparacionesRealizadas = table.Column<int>(type: "int", nullable: true),
                    vehiculosAsignados = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLEADOS", x => x.idEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOS",
                columns: table => new
                {
                    Idproducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    oferta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    devoluciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOS", x => x.Idproducto);
                });

            migrationBuilder.CreateTable(
                name: "RUTAS",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distanciaKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RUTAS", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "VEHICULOS",
                columns: table => new
                {
                    placa = table.Column<int>(type: "int", nullable: false),
                    vehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rendimiento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipoCombustible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioCombustible = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    LicenciausoUrbano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licenciaEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICULOS", x => x.placa);
                });

            migrationBuilder.CreateTable(
                name: "VIAJES",
                columns: table => new
                {
                    idViaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehiculoId = table.Column<int>(type: "int", nullable: false),
                    empleadoid = table.Column<int>(type: "int", nullable: false),
                    rutaId = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIAJES");

            migrationBuilder.DropTable(
                name: "EMPLEADOS");

            migrationBuilder.DropTable(
                name: "PRODUCTOS");

            migrationBuilder.DropTable(
                name: "RUTAS");

            migrationBuilder.DropTable(
                name: "VEHICULOS");
        }
    }
}
