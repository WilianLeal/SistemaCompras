using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class SolicitacaoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameColumn(
                name: "TotalGeral",
                table: "SolicitacaoCompra",
                newName: "Preco");

            migrationBuilder.AddColumn<Guid>(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NomeFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId",
                principalTable: "NomeFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "UsuarioSolicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "NomeFornecedor");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "SolicitacaoCompra",
                newName: "TotalGeral");

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
