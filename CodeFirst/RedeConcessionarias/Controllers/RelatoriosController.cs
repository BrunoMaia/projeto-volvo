using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using RedeConcessionarias.Models;
using RedeConcessionarias.Log;
using System.Linq;
using RedeConcessionarias.configurador;

namespace RedeConcessionarias.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase{
        [HttpGet("salarioVendedores")]
        public IActionResult GetSalarioVendedores(){
            /* Obtem uma tabela com todos os vendedores e seus respectivos salários */
            try{
                using(var _context = new RedeConcessionariaContext()){
                var vendedores = _context.Vendedores.ToList();
                var SalarioMinimo = Config.ObtemSalario();
                    foreach(Vendedor i in vendedores){
                        i.SalarioVendedor = i.VendasMesVendedor*0.01 + SalarioMinimo + i.BonusDestaqueVendedor;
                    }
                    _context.SaveChanges();
                    return Ok(vendedores);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetSalarioVendedores");
                return StatusCode(500,"Erro no Servidor");
            }
        }
        [HttpGet("pagamentoVendedores")]
        public IActionResult GetPagamentoVendedores(){
            /* Retorna um csv com a folha de pagamento dos vendedores */
            try{
                using(var _context = new RedeConcessionariaContext()){
                var Vendedores = _context.Vendedores.ToList();
                var SalarioMinimo = Config.ObtemSalario();
                var Csv = "Cpf; Nome; Venda Total; Salário; Bonus;\n";
                    foreach(Vendedor i in Vendedores){
                        Csv += i.CpfVendedor+";"+i.NomeVendedor+";"+i.VendasMesVendedor+";"+i.SalarioVendedor+";"+i.BonusDestaqueVendedor+";\n";
                    }
                    Config.DefineAtualizado();
                    return File(new System.Text.UTF8Encoding().GetBytes(Csv), "text/csv", "Relatorio.csv");
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetPagamentoVendedores");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    }
}