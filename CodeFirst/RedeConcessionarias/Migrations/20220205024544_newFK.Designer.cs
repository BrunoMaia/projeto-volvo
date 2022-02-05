﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedeConcessionarias.Models;

#nullable disable

namespace RedeConcessionarias.Migrations
{
    [DbContext(typeof(RedeConcessionariaContext))]
    [Migration("20220205024544_newFK")]
    partial class newFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RedeConcessionarias.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("CadastroCliente")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("EmailCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoClienteBairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoClienteCidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoClienteComplemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoClienteLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoClienteNumero")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneCliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RedeConcessionarias.Models.Veiculo", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVeiculo"), 1L, 1);

                    b.Property<string>("AcessoriosVeiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnoVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("ChassiVeiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorVeiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KmVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("ModeloVeiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorVeiculo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VersaoSistVeiculo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdVeiculo");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("RedeConcessionarias.Models.Venda", b =>
                {
                    b.Property<int>("IdVendas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVendas"), 1L, 1);

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<int?>("MatriculaVendedor")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoIdVeiculo")
                        .HasColumnType("int");

                    b.Property<int>("VendedorMatriculaVendedor")
                        .HasColumnType("int");

                    b.HasKey("IdVendas");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("VeiculoIdVeiculo");

                    b.HasIndex("VendedorMatriculaVendedor");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("RedeConcessionarias.Models.Vendedor", b =>
                {
                    b.Property<int>("MatriculaVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatriculaVendedor"), 1L, 1);

                    b.Property<DateTime>("AdmissaoVendedor")
                        .HasColumnType("datetime2");

                    b.Property<string>("CpfVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SalarioVendedor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TelefoneVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendasMesVendedor")
                        .HasColumnType("int");

                    b.Property<int>("VendasTotalVendedor")
                        .HasColumnType("int");

                    b.HasKey("MatriculaVendedor");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("RedeConcessionarias.Models.Venda", b =>
                {
                    b.HasOne("RedeConcessionarias.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedeConcessionarias.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoIdVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedeConcessionarias.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorMatriculaVendedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");

                    b.Navigation("Vendedor");
                });
#pragma warning restore 612, 618
        }
    }
}
