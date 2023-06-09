﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    public partial class TagsNotasNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioPaiId",
                table: "Usuario",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioPaiId",
                table: "Usuario");
        }
    }
}
