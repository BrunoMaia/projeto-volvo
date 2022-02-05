using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeConcessionarias.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_IdClienteNavigationIdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_IdVeiculoNavigationIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_MatriculaVendedorNavigationMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdClienteNavigationIdCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdVeiculoNavigationIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_MatriculaVendedorNavigationMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IdClienteNavigationIdCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IdVeiculoNavigationIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "MatriculaVendedorNavigationMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "IdVeiculo",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeiculoIdVeiculo",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendedorMatriculaVendedor",
                table: "Vendas",
                type: "int",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VeiculoIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VendedorMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "VeiculoIdVeiculo",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "VendedorMatriculaVendedor",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "IdVeiculo",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClienteNavigationIdCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVeiculoNavigationIdVeiculo",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatriculaVendedorNavigationMatriculaVendedor",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_IdClienteNavigationIdCliente",
                table: "Vendas",
                column: "IdClienteNavigationIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_IdVeiculoNavigationIdVeiculo",
                table: "Vendas",
                column: "IdVeiculoNavigationIdVeiculo",
                principalTable: "Veiculos",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_MatriculaVendedorNavigationMatriculaVendedor",
                table: "Vendas",
                column: "MatriculaVendedorNavigationMatriculaVendedor",
                principalTable: "Vendedores",
                principalColumn: "MatriculaVendedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
