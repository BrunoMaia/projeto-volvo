using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Vendedor
    {
       
        [Key]
        public int MatriculaVendedor { get; set; }
        public string? NomeVendedor { get; set; } 
        public string? CpfVendedor { get; set; } 
        public string? EmailVendedor { get; set; } 
        public string? TelefoneVendedor { get; set; } 
        public DateTime AdmissaoVendedor { get; set; }
        public int VendasMesVendedor { get; set; }
        public int VendasTotalVendedor { get; set; }
        public decimal SalarioVendedor { get; set; }

    }
}
