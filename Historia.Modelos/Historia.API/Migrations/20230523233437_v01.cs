using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Historia.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mitologias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    PaisOrigen = table.Column<string>(type: "TEXT", nullable: false),
                    FechaOrigen = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitologias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dioses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreDivino = table.Column<string>(type: "TEXT", nullable: true),
                    NombrePopular = table.Column<string>(type: "TEXT", nullable: false),
                    Elemento = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    MitologiaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dioses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dioses_Mitologias_MitologiaId",
                        column: x => x.MitologiaId,
                        principalTable: "Mitologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dioses_MitologiaId",
                table: "Dioses",
                column: "MitologiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dioses");

            migrationBuilder.DropTable(
                name: "Mitologias");
        }
    }
}
