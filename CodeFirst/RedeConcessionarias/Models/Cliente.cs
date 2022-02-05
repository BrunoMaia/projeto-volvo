using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedeConcessionarias.Models
{
    public class Cliente
    {
        
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(45)]
        public string NomeCliente { get; set; } = null!;
        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(14)]
        public string CadastroCliente { get; set; } = null!;
        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(45)]
        public string EmailCliente { get; set; } = null!;
        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(15)]
        public string TelefoneCliente { get; set; } = null!;
        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(45)]
        public string EnderecoClienteCidade { get; set; } = null!;

        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(45)]
        public string EnderecoClienteBairro { get; set; } = null!;
        [Required(ErrorMessage="Campo obrigatório!!")]
        [StringLength(45)]
        public string EnderecoClienteLogradouro { get; set; } = null!;
        [Required(ErrorMessage="Campo obrigatório!!")]
        public int EnderecoClienteNumero { get; set; }
        [Required(ErrorMessage="Campo obrigatório!!")]
        public int CEPCLliente {get;set;}
        public string? EnderecoClienteComplemento { get; set; }

        public virtual ICollection<Venda> Venda { get; set; } = null!;
    }
}
