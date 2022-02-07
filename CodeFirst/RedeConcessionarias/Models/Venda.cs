using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Venda
    {
        public Venda()
        {
            
        }

       // (IsUnique = true)

        [Key]
        public int VendasId { get; set; }

        public int VendedorId { get; set; }

        public Vendedor? Vendedor { get; set; } 

        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; } 

        public int ClienteId  { get; set; }
        
        //[ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; } 

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataVenda { get; set; }

    }
}
