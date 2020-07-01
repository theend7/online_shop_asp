using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaAspDarko.EFDataAccess.Migrations
{
    public partial class added_relation_slika_proizvod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    SlikaPutanja = table.Column<string>(maxLength: 150, nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slike_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slike_ProizvodId",
                table: "Slike",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_SlikaPutanja",
                table: "Slike",
                column: "SlikaPutanja",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slike");
        }
    }
}
