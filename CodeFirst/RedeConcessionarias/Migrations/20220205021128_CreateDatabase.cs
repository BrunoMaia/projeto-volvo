using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeConcessionarias.Migrations
{
    public partial class CreateDatabase : Migration
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
                    MatriculaVendedor = table.Column<int>(type: "int", nullable: false),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClienteNavigationIdCliente = table.Column<int>(type: "int", nullable: false),
                    IdVeiculoNavigationIdVeiculo = table.Column<int>(type: "int", nullable: false),
                    MatriculaVendedorNavigationMatriculaVendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVendas);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_IdClienteNavigationIdCliente",
                        column: x => x.IdClienteNavigationIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Veiculos_IdVeiculoNavigationIdVeiculo",
                        column: x => x.IdVeiculoNavigationIdVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_MatriculaVendedorNavigationMatriculaVendedor",
                        column: x => x.MatriculaVendedorNavigationMatriculaVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "MatriculaVendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdClienteNavigationIdCliente",
                table: "Vendas",
                column: "IdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdVeiculoNavigationIdVeiculo",
                table: "Vendas",
                column: "IdVeiculoNavigationIdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_MatriculaVendedorNavigationMatriculaVendedor",
                table: "Vendas",
                column: "MatriculaVendedorNavigationMatriculaVendedor");
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
