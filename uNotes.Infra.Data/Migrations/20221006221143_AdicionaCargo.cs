using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    public partial class AdicionaCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cargo_CargoId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cargo",
                table: "Cargo");

            migrationBuilder.RenameTable(
                name: "Cargo",
                newName: "Cargos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataExclusao",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataExclusao",
                table: "Cargos",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Cargos",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cargos",
                table: "Cargos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cargos_CargoId",
                table: "Usuario",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cargos_CargoId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cargos",
                table: "Cargos");

            migrationBuilder.RenameTable(
                name: "Cargos",
                newName: "Cargo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataExclusao",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataExclusao",
                table: "Cargo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Cargo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cargo",
                table: "Cargo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cargo_CargoId",
                table: "Usuario",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
