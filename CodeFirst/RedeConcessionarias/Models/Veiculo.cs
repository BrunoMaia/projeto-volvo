using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Veiculo
    {
      
        [Key]
        public int IdVeiculo { get; set; }
        public string ChassiVeiculo { get; set; } = null!;
        public string ModeloVeiculo { get; set; } = null!;
        public int AnoVeiculo { get; set; }
        public string CorVeiculo { get; set; } = null!;
        public decimal ValorVeiculo { get; set; }
        public int KmVeiculo { get; set; }
        public string? AcessoriosVeiculo { get; set; }
        public decimal VersaoSistVeiculo { get; set; } 

        public virtual ICollection<Venda> Venda { get; set; } = null!;
    }
}
