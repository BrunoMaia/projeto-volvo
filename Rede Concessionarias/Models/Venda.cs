using System;
using System.Collections.Generic;

namespace Projeto___Concessionaria.Models
{
    public partial class Venda
    {
        public int IdVendas { get; set; }
        public int MatriculaVendedor { get; set; }
        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataVenda { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Veiculo IdVeiculoNavigation { get; set; } = null!;
        public virtual Vendedor MatriculaVendedorNavigation { get; set; } = null!;
    }
}
