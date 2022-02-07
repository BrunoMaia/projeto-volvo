using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeConcessionarias.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    VendedorId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Vendedores", x => x.VendedorId);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendasId);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");
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
