using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaAspDarko.EFDataAccess.Migrations
{
    public partial class added_relations_klijent_proizvod_porudzbina_detaljiPorudzbine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Porudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    DatumPorudzbine = table.Column<DateTime>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    PorudzbinaStatus = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porudzbine_Klijenti_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiPorudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    Cena = table.Column<decimal>(nullable: false),
                    PorudzbinaId = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiPorudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaljiPorudzbine_Porudzbine_PorudzbinaId",
                        column: x => x.PorudzbinaId,
                        principalTable: "Porudzbine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetaljiPorudzbine_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiPorudzbine_PorudzbinaId",
                table: "DetaljiPorudzbine",
                column: "PorudzbinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiPorudzbine_ProizvodId",
                table: "DetaljiPorudzbine",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbine_KlijentId",
                table: "Porudzbine",
                column: "KlijentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaljiPorudzbine");

            migrationBuilder.DropTable(
                name: "Porudzbine");
        }
    }
}
