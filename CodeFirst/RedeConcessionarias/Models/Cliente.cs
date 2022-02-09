using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RedeConcessionarias.Models{
    public class Cliente
        {
        public int ClienteId { get; set; }
        public string? NomeCliente { get; set; } 
        [MinLength(11,ErrorMessage = "Dados em tamanho inválido."),MaxLength(14,ErrorMessage = "Dados em tamanho inválido.")]
        
        public string? CadastroCliente { get; set; } 
        
        [EmailAddress(ErrorMessage = "E-mail inválido.")] 
        public string? EmailCliente { get; set; } 
        public string? TelefoneCliente { get; set; } 
        public string? EnderecoClienteCidade { get; set; } 
        public string? EnderecoClienteBairro { get; set; } 
        public string? EnderecoClienteLogradouro { get; set; } 
        public int? EnderecoClienteNumero { get; set; }
        public string? EnderecoClienteComplemento { get; set; }
        
        public ICollection<Venda> Vendas { get; set; }
        public Cliente(){
            Vendas = new Collection<Venda>();
        }
    }
}
