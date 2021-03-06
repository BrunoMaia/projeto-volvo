using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RedeConcessionarias.Log;
using RedeConcessionarias.configurador;
using System.Linq;

namespace RedeConcessionarias.Models{
    public class Vendedor{
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
        public string DestaqueVendedor { get; set; }
        public double BonusDestaqueVendedor { get; set; }
       public ICollection<Venda>? Vendas { get; set; }
       public Vendedor(){
            this.Vendas = new Collection<Venda>();
            this.VendasMesVendedor = 0;
            this.SalarioVendedor = Config.ObtemSalario();
            this.DestaqueVendedor = "Não";
            this.BonusDestaqueVendedor = 0;
        }
        public static void DestaqueDoMes(Vendedor vendedor){
            try{
                    using(var _context = new RedeConcessionariaContext()){
                        var destaque = _context.Vendedores.Where(v =>  v.DestaqueVendedor == "Sim").Select(t => t);
                        //se não houver presente destaque do mês, então torna o vendedor que fez a venda o novo destaque do mês
                        if(destaque.FirstOrDefault() == null){
                            vendedor.DestaqueVendedor = "Sim";
                            vendedor.BonusDestaqueVendedor = 3000;
                            _context.SaveChanges();
                            return;
                        }
                        // Pega da query o valor de vendas do vendedor que é o atual destaque do mês 
                        double valorComparado = destaque.Select(t => t.VendasMesVendedor).FirstOrDefault(); 
                        //verifica se superou o valor de vendas do atual destaque e, se sim, faz a atualização dos valores para o novo destaque do mês e o antigo destaque do mês perde o bônus e volta a ser um vendedor comum
                        if (vendedor.VendasMesVendedor > valorComparado){
                            foreach (Vendedor atualDestaque in destaque){
                                        atualDestaque.DestaqueVendedor = "Não";
                                        atualDestaque.BonusDestaqueVendedor = 0;
                                    }
                            vendedor.DestaqueVendedor = "Sim";
                            vendedor.BonusDestaqueVendedor = 3000;
                            _context.SaveChanges();
                            return;
                        }                                                       
                        return;
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,2,"Vendedor.DestaqueDoMês");
                    return;
                }
        }
    }
}
