
using Microsoft.EntityFrameworkCore;


namespace RedeConcessionarias.Models
{
    public class RedeConcessionariaContext : DbContext
    {

        
        public  DbSet<Cliente> Clientes { get; set; } = null!;
        public  DbSet<Veiculo> Veiculos { get; set; } = null!;
        public  DbSet<Vendedor> Vendedores { get; set; } = null!;
        public  DbSet<Venda> Vendas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
        
                optionBuilder.UseSqlServer(
                @"Server = .\; Database = RedeConcessionaria; Trusted_Connection = True;");
        }
    }
}

