using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeConcessionarias.Migrations
{
    public partial class AlteraDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CadastroCliente = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoClienteCidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoClienteBairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoClienteLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoClienteNumero = table.Column<int>(type: "int", nullable: true),
                    EnderecoClienteComplemento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassiVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeloVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoVeiculo = table.Column<int>(type: "int", nullable: false),
                    CorVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorVeiculo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmVeiculo = table.Column<int>(type: "int", nullable: false),
                    AcessoriosVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersaoSistVeiculo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.IdVeiculo);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    MatriculaVendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissaoVendedor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendasMesVendedor = table.Column<int>(type: "int", nullable: false),
                    VendasTotalVendedor = table.Column<int>(type: "int", nullable: false),
                    SalarioVendedor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.MatriculaVendedor);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVendas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorMatriculaVendedor = table.Column<int>(type: "int", nullable: true),
                    VeiculoIdVeiculo = table.Column<int>(type: "int", nullable: true),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVendas);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Vendas_Veiculos_VeiculoIdVeiculo",
                        column: x => x.VeiculoIdVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "IdVeiculo");
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_VendedorMatriculaVendedor",
                        column: x => x.VendedorMatriculaVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "MatriculaVendedor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoIdVeiculo",
                table: "Vendas",
                column: "VeiculoIdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorMatriculaVendedor",
                table: "Vendas",
                column: "VendedorMatriculaVendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
