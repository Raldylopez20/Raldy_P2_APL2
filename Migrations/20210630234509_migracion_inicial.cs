using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raldy_P2_APL2.Migrations
{
    public partial class migracion_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCobrado = table.Column<double>(type: "REAL", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<float>(type: "REAL", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    CobroNoPerdiente = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cobrado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cobrado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Nombres" },
                values: new object[] { 1, "FERRETERIA GAMA" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Nombres" },
                values: new object[] { 2, "AVALON DISCO" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Nombres" },
                values: new object[] { 3, "PRESTAMOS CEFIPROD" });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Cobrado", "CobroNoPerdiente", "Fecha", "Monto" },
                values: new object[] { 1, 1000.0, 1, 0.0, false, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000f });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Cobrado", "CobroNoPerdiente", "Fecha", "Monto" },
                values: new object[] { 2, 800.0, 1, 0.0, false, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900f });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Cobrado", "CobroNoPerdiente", "Fecha", "Monto" },
                values: new object[] { 3, 2000.0, 2, 0.0, false, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000f });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Cobrado", "CobroNoPerdiente", "Fecha", "Monto" },
                values: new object[] { 4, 1800.0, 2, 0.0, false, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1900f });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Cobrado", "CobroNoPerdiente", "Fecha", "Monto" },
                values: new object[] { 5, 3000.0, 3, 0.0, false, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000f });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Cobrado", "CobroNoPerdiente", "Fecha", "Monto" },
                values: new object[] { 6, 1900.0, 3, 0.0, false, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2900f });

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_CobroId",
                table: "CobrosDetalle",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_VentaId",
                table: "CobrosDetalle",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrosDetalle");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
