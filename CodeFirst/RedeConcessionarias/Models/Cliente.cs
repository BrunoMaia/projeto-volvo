using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Cliente
    {
        
        [Key]
        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; } 
        [MaxLength(14),MinLength(11)]
        public string? CadastroCliente { get; set; } 
        public string? EmailCliente { get; set; } 
        public string? TelefoneCliente { get; set; } 
        public string? EnderecoClienteCidade { get; set; } 
        public string? EnderecoClienteBairro { get; set; } 
        public string? EnderecoClienteLogradouro { get; set; } 
        public int? EnderecoClienteNumero { get; set; }
        public string? EnderecoClienteComplemento { get; set; }

    }
}
