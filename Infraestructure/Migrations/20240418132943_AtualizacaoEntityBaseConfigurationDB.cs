using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoEntityBaseConfigurationDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Atualizar",
                table: "Pedido",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Atualizar",
                table: "Livro",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Atualizar",
                table: "Cliente",
                type: "DATETIME",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atualizar",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Atualizar",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Atualizar",
                table: "Cliente");
        }
    }
}
