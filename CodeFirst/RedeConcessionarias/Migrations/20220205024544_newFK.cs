using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeConcessionarias.Migrations
{
    public partial class newFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_VeiculoIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "VendedorMatriculaVendedor",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeiculoIdVeiculo",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatriculaVendedor",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_VeiculoIdVeiculo",
                table: "Vendas",
                column: "VeiculoIdVeiculo",
                principalTable: "Veiculos",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorMatriculaVendedor",
                table: "Vendas",
                column: "VendedorMatriculaVendedor",
                principalTable: "Vendedores",
                principalColumn: "MatriculaVendedor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_VeiculoIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "VendedorMatriculaVendedor",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VeiculoIdVeiculo",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatriculaVendedor",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_VeiculoIdVeiculo",
                table: "Vendas",
                column: "VeiculoIdVeiculo",
                principalTable: "Veiculos",
                principalColumn: "IdVeiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorMatriculaVendedor",
                table: "Vendas",
                column: "VendedorMatriculaVendedor",
                principalTable: "Vendedores",
                principalColumn: "MatriculaVendedor");
        }
    }
}
