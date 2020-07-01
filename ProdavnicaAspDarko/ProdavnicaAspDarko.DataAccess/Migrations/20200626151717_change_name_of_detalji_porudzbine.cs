using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaAspDarko.EFDataAccess.Migrations
{
    public partial class change_name_of_detalji_porudzbine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetaljiPorudzbine_Porudzbine_PorudzbinaId",
                table: "DetaljiPorudzbine");

            migrationBuilder.DropForeignKey(
                name: "FK_DetaljiPorudzbine_Proizvodi_ProizvodId",
                table: "DetaljiPorudzbine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetaljiPorudzbine",
                table: "DetaljiPorudzbine");

            migrationBuilder.RenameTable(
                name: "DetaljiPorudzbine",
                newName: "DetaljiPorudzbina");

            migrationBuilder.RenameIndex(
                name: "IX_DetaljiPorudzbine_ProizvodId",
                table: "DetaljiPorudzbina",
                newName: "IX_DetaljiPorudzbina_ProizvodId");

            migrationBuilder.RenameIndex(
                name: "IX_DetaljiPorudzbine_PorudzbinaId",
                table: "DetaljiPorudzbina",
                newName: "IX_DetaljiPorudzbina_PorudzbinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetaljiPorudzbina",
                table: "DetaljiPorudzbina",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetaljiPorudzbina_Porudzbine_PorudzbinaId",
                table: "DetaljiPorudzbina",
                column: "PorudzbinaId",
                principalTable: "Porudzbine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetaljiPorudzbina_Proizvodi_ProizvodId",
                table: "DetaljiPorudzbina",
                column: "ProizvodId",
                principalTable: "Proizvodi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetaljiPorudzbina_Porudzbine_PorudzbinaId",
                table: "DetaljiPorudzbina");

            migrationBuilder.DropForeignKey(
                name: "FK_DetaljiPorudzbina_Proizvodi_ProizvodId",
                table: "DetaljiPorudzbina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetaljiPorudzbina",
                table: "DetaljiPorudzbina");

            migrationBuilder.RenameTable(
                name: "DetaljiPorudzbina",
                newName: "DetaljiPorudzbine");

            migrationBuilder.RenameIndex(
                name: "IX_DetaljiPorudzbina_ProizvodId",
                table: "DetaljiPorudzbine",
                newName: "IX_DetaljiPorudzbine_ProizvodId");

            migrationBuilder.RenameIndex(
                name: "IX_DetaljiPorudzbina_PorudzbinaId",
                table: "DetaljiPorudzbine",
                newName: "IX_DetaljiPorudzbine_PorudzbinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetaljiPorudzbine",
                table: "DetaljiPorudzbine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetaljiPorudzbine_Porudzbine_PorudzbinaId",
                table: "DetaljiPorudzbine",
                column: "PorudzbinaId",
                principalTable: "Porudzbine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetaljiPorudzbine_Proizvodi_ProizvodId",
                table: "DetaljiPorudzbine",
                column: "ProizvodId",
                principalTable: "Proizvodi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
