using Microsoft.EntityFrameworkCore.Migrations;

namespace Meditours.Migrations
{
    public partial class Example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camioneta",
                columns: table => new
                {
                    PkCamioneta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    CantidadMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camioneta", x => x.PkCamioneta);
                });

            migrationBuilder.CreateTable(
                name: "itinerario",
                columns: table => new
                {
                    PkItinerario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lugar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tiempo = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itinerario", x => x.PkItinerario);
                });

            migrationBuilder.CreateTable(
                name: "Metodo_pago",
                columns: table => new
                {
                    PkMetodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodo_pago", x => x.PkMetodo);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    PkCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkUsuario = table.Column<int>(type: "int", nullable: false),
                    FkCamioneta = table.Column<int>(type: "int", nullable: false),
                    ModeloCamioneta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkMetodo_pago = table.Column<int>(type: "int", nullable: false),
                    metodo_PagoPkMetodo = table.Column<int>(type: "int", nullable: true),
                    Metodo_pago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio_Final = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.PkCarrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Camioneta_FkCamioneta",
                        column: x => x.FkCamioneta,
                        principalTable: "Camioneta",
                        principalColumn: "PkCamioneta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Metodo_pago_metodo_PagoPkMetodo",
                        column: x => x.metodo_PagoPkMetodo,
                        principalTable: "Metodo_pago",
                        principalColumn: "PkMetodo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carrito_usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "usuarios",
                        principalColumn: "PkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_FkCamioneta",
                table: "Carrito",
                column: "FkCamioneta");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_FkUsuario",
                table: "Carrito",
                column: "FkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_metodo_PagoPkMetodo",
                table: "Carrito",
                column: "metodo_PagoPkMetodo");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FkRol",
                table: "usuarios",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "itinerario");

            migrationBuilder.DropTable(
                name: "Camioneta");

            migrationBuilder.DropTable(
                name: "Metodo_pago");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
