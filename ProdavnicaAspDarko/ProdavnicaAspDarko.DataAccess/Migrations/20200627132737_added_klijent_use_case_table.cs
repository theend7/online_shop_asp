using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaAspDarko.EFDataAccess.Migrations
{
    public partial class added_klijent_use_case_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KlijentUseCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false),
                    UseCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentUseCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlijentUseCases_Klijenti_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlijentUseCases_KlijentId",
                table: "KlijentUseCases",
                column: "KlijentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlijentUseCases");
        }
    }
}
