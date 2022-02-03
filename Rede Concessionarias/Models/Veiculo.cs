using System;
using System.Collections.Generic;

namespace Projeto___Concessionaria.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Venda = new HashSet<Vendum>();
        }

        public int IdVeiculo { get; set; }
        public string ChassiVeiculo { get; set; } = null!;
        public string ModeloVeiculo { get; set; } = null!;
        public int AnoVeiculo { get; set; }
        public string CorVeiculo { get; set; } = null!;
        public decimal ValorVeiculo { get; set; }
        public int KmVeiculo { get; set; }
        public string? AcessoriosVeiculo { get; set; }
        public decimal VersaoSistVeiculo { get; set; } = null!;

        public virtual ICollection<Vendum> Venda { get; set; }
    }
}
