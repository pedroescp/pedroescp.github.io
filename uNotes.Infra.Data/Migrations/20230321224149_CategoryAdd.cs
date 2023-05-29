using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    public partial class CategoryAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosGrupos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropColumn(
                name: "DocumentoId",
                table: "Notes");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Documentos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    CategoriaPai = table.Column<Guid>(type: "uuid", nullable: true),
                    CriadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotasDocumento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    CriadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasDocumento_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosCategorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosCategorias_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_CategoriaId",
                table: "Documentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasDocumento_DocumentoId",
                table: "NotasDocumento",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCategorias_CategoriaId",
                table: "UsuariosCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCategorias_UsuarioId",
                table: "UsuariosCategorias",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Categorias_CategoriaId",
                table: "Documentos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Categorias_CategoriaId",
                table: "Documentos");

            migrationBuilder.DropTable(
                name: "NotasDocumento");

            migrationBuilder.DropTable(
                name: "UsuariosCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_CategoriaId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Documentos");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentoId",
                table: "Notes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosGrupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosGrupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosGrupos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosGrupos_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosGrupos_GrupoId",
                table: "UsuariosGrupos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosGrupos_UsuarioId",
                table: "UsuariosGrupos",
                column: "UsuarioId");
        }
    }
}
