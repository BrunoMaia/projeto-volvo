using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Venda
    {
        [Key]
        public int IdVendas { get; set; }
        public int? MatriculaVendedor { get; set; }
        public Vendedor Vendedor { get; set; } 
        public int? IdVeiculo { get; set; }

        public Veiculo Veiculo { get; set; } 
        public int? IdCliente { get; set; }
        public Cliente Cliente { get; set; } 
        public DateTime DataVenda { get; set; }

/*
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Veiculo IdVeiculoNavigation  { get; set; } = null!;
        public virtual Vendedor MatriculaVendedorNavigation  { get; set; } = null!; 
*/
    }
}
