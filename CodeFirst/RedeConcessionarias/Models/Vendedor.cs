using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RedeConcessionarias.Models
{
    public class Vendedor
    {

        public Vendedor()
        {
            this.Vendas = new Collection<Venda>();
            this.VendasMesVendedor = 0;
            this.SalarioVendedor = 1212;
            this.DestaqueVendedor = false;
            this.BonusDestaqueVendedor = 0;
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

        public double VendasMesVendedor { get; set; }

        public double SalarioVendedor { get; set; }
        public bool? DestaqueVendedor { get; set; }

        public double BonusDestaqueVendedor { get; set; }

       public ICollection<Venda>? Vendas { get; set; }

    }
}
