using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoquei.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoEstoquei2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMovimentacao",
                columns: table => new
                {
                    IdTipoMovimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoMovimentacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimentacao", x => x.IdTipoMovimentacao);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.TipoProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoProduto = table.Column<int>(type: "int", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false),
                    StatusProduto = table.Column<bool>(type: "bit", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "TipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntradaESaida",
                columns: table => new
                {
                    IdEntradaESaida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMovimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoMovimentacao = table.Column<int>(type: "int", nullable: false),
                    TipoMovimentacaoId = table.Column<int>(type: "int", nullable: true),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaESaida", x => x.IdEntradaESaida);
                    table.ForeignKey(
                        name: "FK_EntradaESaida_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaESaida_TipoMovimentacao_TipoMovimentacaoId",
                        column: x => x.TipoMovimentacaoId,
                        principalTable: "TipoMovimentacao",
                        principalColumn: "IdTipoMovimentacao");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaESaida_ProdutoId",
                table: "EntradaESaida",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaESaida_TipoMovimentacaoId",
                table: "EntradaESaida",
                column: "TipoMovimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoProdutoId",
                table: "Produto",
                column: "TipoProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaESaida");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "TipoMovimentacao");

            migrationBuilder.DropTable(
                name: "TipoProduto");
        }
    }
}
