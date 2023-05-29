using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    public partial class MudancaEmNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fixado",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Lixeira",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Notes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notes");

            migrationBuilder.AddColumn<bool>(
                name: "Fixado",
                table: "Notes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lixeira",
                table: "Notes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
