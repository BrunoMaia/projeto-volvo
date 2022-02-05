using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Cliente
    {
        
        [Key]
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; } = null!;
        public string CadastroCliente { get; set; } = null!;
        public string EmailCliente { get; set; } = null!;
        public string TelefoneCliente { get; set; } = null!;
        public string EnderecoClienteCidade { get; set; } = null!;
        public string EnderecoClienteBairro { get; set; } = null!;
        public string EnderecoClienteLogradouro { get; set; } = null!;
        public int EnderecoClienteNumero { get; set; }
        public string? EnderecoClienteComplemento { get; set; }

        public virtual ICollection<Venda> Venda { get; set; } = null!;
    }
}
