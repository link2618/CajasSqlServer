using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cajas_SqlServer_Login.Data.Migrations
{
    public partial class MigracionModelosCajaTipoCajaCarpeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ttipocaja",
                columns: table => new
                {
                    idtipocaja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttipocaja", x => x.idtipocaja);
                });

            migrationBuilder.CreateTable(
                name: "tcaja",
                columns: table => new
                {
                    idtcaja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_registro = table.Column<DateTime>(nullable: false),
                    fecha_cierre = table.Column<DateTime>(nullable: false),
                    usuario = table.Column<string>(nullable: true),
                    anio = table.Column<int>(nullable: false),
                    tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tcaja", x => x.idtcaja);
                    table.ForeignKey(
                        name: "FK_tcaja_ttipocaja_tipo",
                        column: x => x.tipo,
                        principalTable: "ttipocaja",
                        principalColumn: "idtipocaja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tcarpeta",
                columns: table => new
                {
                    idcarpeta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nit = table.Column<int>(nullable: false),
                    fecha_registro = table.Column<DateTime>(nullable: false),
                    fecha_cierre = table.Column<DateTime>(nullable: false),
                    caja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tcarpeta", x => x.idcarpeta);
                    table.ForeignKey(
                        name: "FK_tcarpeta_tcaja_caja",
                        column: x => x.caja,
                        principalTable: "tcaja",
                        principalColumn: "idtcaja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tcaja_tipo",
                table: "tcaja",
                column: "tipo");

            migrationBuilder.CreateIndex(
                name: "IX_tcarpeta_caja",
                table: "tcarpeta",
                column: "caja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tcarpeta");

            migrationBuilder.DropTable(
                name: "tcaja");

            migrationBuilder.DropTable(
                name: "ttipocaja");
        }
    }
}
