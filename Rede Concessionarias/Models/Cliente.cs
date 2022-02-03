using System;
using System.Collections.Generic;

namespace Projeto___Concessionaria.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venda = new HashSet<Vendum>();
        }

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

        public virtual ICollection<Vendum> Venda { get; set; }
    }
}
