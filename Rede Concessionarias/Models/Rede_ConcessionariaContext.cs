using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Projeto___Concessionaria.Models
{
    public partial class Rede_ConcessionariaContext : DbContext
    {
        public Rede_ConcessionariaContext()
        {
        }

        public Rede_ConcessionariaContext(DbContextOptions<Rede_ConcessionariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Veiculo> Veiculos { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;
        public virtual DbSet<Vendum> Venda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =.\\; Database = Rede_Concessionaria; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642D9F034B5");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.TelefoneCliente, "UQ__Cliente__0599FE0BA2F25DD5")
                    .IsUnique();

                entity.HasIndex(e => e.CadastroCliente, "UQ__Cliente__5AED5EFA8BBEBCE5")
                    .IsUnique();

                entity.HasIndex(e => e.EmailCliente, "UQ__Cliente__C37FFD2D180A3A7B")
                    .IsUnique();

                entity.Property(e => e.CadastroCliente)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoClienteBairro)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoClienteCidade)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoClienteComplemento)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoClienteLogradouro)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo)
                    .HasName("PK__Veiculo__CAC4F346A85DC321");

                entity.ToTable("Veiculo");

                entity.HasIndex(e => e.ChassiVeiculo, "UQ__Veiculo__36CBE062C54BC3D5")
                    .IsUnique();

                entity.Property(e => e.AcessoriosVeiculo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ChassiVeiculo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CorVeiculo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ModeloVeiculo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ValorVeiculo).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.VersaoSistVeiculo).HasColumnType("decimal(5, 5)");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.MatriculaVendedor)
                    .HasName("PK__Vendedor__BF0608EA2726D284");

                entity.ToTable("Vendedor");

                entity.HasIndex(e => e.TelefoneVendedor, "UQ__Vendedor__97ED50AB6C87E239")
                    .IsUnique();

                entity.HasIndex(e => e.EmailVendedor, "UQ__Vendedor__DAFEFF3791BE6FD4")
                    .IsUnique();

                entity.HasIndex(e => e.CpfVendedor, "UQ__Vendedor__DCB8A585BE575D61")
                    .IsUnique();

                entity.Property(e => e.AdmissaoVendedor).HasColumnType("date");

                entity.Property(e => e.CpfVendedor)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.EmailVendedor)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVendedor)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SalarioVendedor).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TelefoneVendedor)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendum>(entity =>
            {
                entity.HasKey(e => e.IdVendas)
                    .HasName("PK__Venda__1CE841B460D961D4");

                entity.Property(e => e.DataVenda).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venda__IdCliente__619B8048");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venda__IdVeiculo__60A75C0F");

                entity.HasOne(d => d.MatriculaVendedorNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.MatriculaVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venda__Matricula__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
