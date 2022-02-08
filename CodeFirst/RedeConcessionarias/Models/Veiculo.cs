using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RedeConcessionarias.Models
{
    public class Veiculo
    {

        
      
        [Key]
        public int VeiculoId { get; set; }

        public string? ChassiVeiculo { get; set; } 

        public string? ModeloVeiculo { get; set; } 

        public int AnoVeiculo { get; set; }

        public string? CorVeiculo { get; set; }

        [Required]
        public double ValorVeiculo { get; set; }

        public int KmVeiculo { get; set; }

        public string? AcessoriosVeiculo { get; set; }

        public decimal VersaoSistVeiculo { get; set; } 

        public ICollection<Venda>? Vendas { get; set; }


        public Veiculo()
        {
            Vendas = new Collection<Venda>();
        }

    }
}
