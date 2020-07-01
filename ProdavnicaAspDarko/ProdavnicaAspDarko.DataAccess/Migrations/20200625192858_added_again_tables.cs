using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaAspDarko.EFDataAccess.Migrations
{
    public partial class added_again_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    NazivKategorije = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    NazivUloge = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    NazivProizvoda = table.Column<string>(maxLength: 60, nullable: false),
                    OpisProizvoda = table.Column<string>(maxLength: 200, nullable: false),
                    KolicinaProizvoda = table.Column<int>(nullable: false),
                    SlikaProizvoda = table.Column<string>(maxLength: 150, nullable: false),
                    IdKategorija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvodi_Kategorije_IdKategorija",
                        column: x => x.IdKategorija,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    Jmbg = table.Column<long>(nullable: false),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 55, nullable: false),
                    Lozinka = table.Column<string>(maxLength: 140, nullable: false),
                    IdUloga = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijenti_Uloge_IdUloga",
                        column: x => x.IdUloga,
                        principalTable: "Uloge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_NazivKategorije",
                table: "Kategorije",
                column: "NazivKategorije",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_Email",
                table: "Klijenti",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_IdUloga",
                table: "Klijenti",
                column: "IdUloga");

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_Jmbg",
                table: "Klijenti",
                column: "Jmbg",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_IdKategorija",
                table: "Proizvodi",
                column: "IdKategorija");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_NazivProizvoda",
                table: "Proizvodi",
                column: "NazivProizvoda",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Kategorije");
        }
    }
}
