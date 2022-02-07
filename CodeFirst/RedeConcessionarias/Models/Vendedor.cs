using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Vendedor
    {

        public Vendedor()
        {
        }
       
        [Key]
        public int VendedorId { get; set; }

        public string? NomeVendedor { get; set; } 

        public string? CpfVendedor { get; set; } 

        [EmailAddress(ErrorMessage = "E-mail inválido.")] 
        public string? EmailVendedor { get; set; } 

        public string? TelefoneVendedor { get; set; } 

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime AdmissaoVendedor { get; set; }

        public int VendasMesVendedor { get; set; }

        public int VendasTotalVendedor { get; set; }

        public decimal SalarioVendedor { get; set; }

       // public ICollection<Venda>? Vendas { get; set; }

    }
}
