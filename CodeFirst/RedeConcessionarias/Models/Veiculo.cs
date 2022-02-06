using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Veiculo
    {
      
        [Key]
        public int IdVeiculo { get; set; }

        public string? ChassiVeiculo { get; set; } 

        public string? ModeloVeiculo { get; set; } 

        public int AnoVeiculo { get; set; }

        public string? CorVeiculo { get; set; }

        public decimal ValorVeiculo { get; set; }

        public int KmVeiculo { get; set; }

        public string? AcessoriosVeiculo { get; set; }

        public decimal VersaoSistVeiculo { get; set; } 

        //public ICollection<Venda>? Vendas { get; set; }

    }
}
