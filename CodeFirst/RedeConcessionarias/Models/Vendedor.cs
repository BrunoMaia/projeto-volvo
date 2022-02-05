using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Vendedor
    {
       
        [Key]
        public int MatriculaVendedor { get; set; }
        public string NomeVendedor { get; set; } = null!;
        public string CpfVendedor { get; set; } = null!;
        public string EmailVendedor { get; set; } = null!;
        public string TelefoneVendedor { get; set; } = null!;
        public DateTime AdmissaoVendedor { get; set; }
        public int VendasMesVendedor { get; set; }
        public int VendasTotalVendedor { get; set; }
        public decimal SalarioVendedor { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; } = null!;
    }
}
