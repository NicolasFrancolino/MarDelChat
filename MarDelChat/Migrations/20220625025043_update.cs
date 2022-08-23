using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarDelChat.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuario_IdUsuarioId",
                table: "Contactos");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioId",
                table: "Contactos",
                newName: "UsuarioId1");

            migrationBuilder.RenameIndex(
                name: "IX_Contactos_IdUsuarioId",
                table: "Contactos",
                newName: "IX_Contactos_UsuarioId1");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Contactos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResponse", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_UsuarioId",
                table: "Contactos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_UserResponse_UsuarioId1",
                table: "Contactos",
                column: "UsuarioId1",
                principalTable: "UserResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuario_UsuarioId",
                table: "Contactos",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_UserResponse_UsuarioId1",
                table: "Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuario_UsuarioId",
                table: "Contactos");

            migrationBuilder.DropTable(
                name: "UserResponse");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_UsuarioId",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Contactos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId1",
                table: "Contactos",
                newName: "IdUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Contactos_UsuarioId1",
                table: "Contactos",
                newName: "IX_Contactos_IdUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuario_IdUsuarioId",
                table: "Contactos",
                column: "IdUsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
