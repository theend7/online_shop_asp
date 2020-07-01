using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaAspDarko.EFDataAccess.Migrations
{
    public partial class remove_some_columns_in_klijent_use_case : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "KlijentUseCases");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "KlijentUseCases");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "KlijentUseCases");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "KlijentUseCases");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "KlijentUseCases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "KlijentUseCases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "KlijentUseCases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "KlijentUseCases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "KlijentUseCases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "KlijentUseCases",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
