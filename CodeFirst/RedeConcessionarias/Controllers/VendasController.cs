using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using RedeConcessionarias.Models;
using RedeConcessionarias.Log;
using System.Linq;



namespace RedeConcessionarias.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase{
        [HttpGet]
        public IActionResult GetTodasVendas(){
            /* Lista todas as vendas da empresa */
            try{
                using(var _context = new RedeConcessionariaContext()){
                    return Ok(_context.Vendas.ToList());
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetTodasVendas");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    
        [HttpGet("byId/{VendasId}")] 
        public IActionResult GetVendasById(int VendasId){
            /* Busca o vendedor pela matrícula */
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var venda = _context.Vendas.FirstOrDefault(v=>v.VendasId == VendasId);
                    if(venda == null){
                        return NotFound("Venda não localizada.");
                    }
                    return Ok(venda);
                }
                
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetVendasById");
                return StatusCode(500,"Erro no Servidor");
            }
        
        }

        [HttpPost]
        public  IActionResult PostVenda([FromBody] Venda venda){
            /* Cadastra a venda no banco de dados */
            try{
                using (var _context = new RedeConcessionariaContext()){
                    _context.Vendas.Update(venda);
                    // verifica se aquele veículo já foi vendido anteriormente
                    var validaVeiculo = _context.Vendas.Where(v =>  v.VeiculoId == venda.VeiculoId); 
                    if ( validaVeiculo.FirstOrDefault() != null){
                        return BadRequest("Este veículo já foi vendido.");
                    }
                    _context.SaveChanges(); //Cadastra os dados 
               
                    //faz uma query usando join para verificar na tabela de veículos qual é o valor do veículo vendido
                   var valor =  (from va in _context.Veiculos 
					            join vb in _context.Vendas
					            on va.VeiculoId equals vb.VeiculoId
					            where vb.VendasId == (from venda in _context.Vendas select venda.VendasId).Max()
					            select new {valornegocio = va.ValorVeiculo}).Select(t => t.valornegocio);

                    Venda veiculoNegociado = _context.Vendas.Single(v => v.VendasId == venda.VendasId);
                    veiculoNegociado.ValorVenda = valor.First(); //atualiza na tabela de vendas o valor da venda

                    Vendedor vendedor = _context.Vendedores.Where(n => n.VendedorId == venda.VendedorId).First(); 
                    Veiculo veiculo = _context.Veiculos.Where(n => n.VeiculoId == venda.VeiculoId).First();
                    Cliente cliente = _context.Clientes.Where(n => n.ClienteId == venda.ClienteId).First();

                    vendedor.VendasMesVendedor += valor.First(); //atualiza os valores do vendedor que fez a venda
                    vendedor.SalarioVendedor += valor.First()*0.01; 

                    _context.SaveChanges(); // Cadastra os dados para permitir a atualização dos valores do vendedor, pois será necessário o valor atualizado no método DestaqueDoMês()
                   
                   Vendedor.DestaqueDoMes(vendedor); //Chama o método para verificar se essa venda impulsionou o vendedor para o destaque do mês
                        
                    _context.SaveChanges();
                    return Ok(venda);
               }
                
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"PostVenda");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpPut("{VendasId}")]
        public IActionResult PutVenda(int VendasId, [FromBody] Venda venda){
            /* altera a venda */
            try{
                using(var _context = new RedeConcessionariaContext()){                   
                    var entity = _context.Vendas.Find(VendasId); //Verifica se aquela venda existe no banco de dados
                    if(entity == null){
                        return BadRequest("Venda não localizada.");
                    }
                    _context.Entry(entity).CurrentValues.SetValues(venda); //faz a atualização para os novos valores
                    _context.SaveChanges();
                        return Ok(venda);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"PutVenda");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpDelete("{VendasId}")]
        public IActionResult DeleteVenda(int VendasId){
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var entity = _context.Vendas.Find(VendasId);
                    if(entity == null){
                        return BadRequest("Venda não localizada.");
                    }
                        _context.Vendas.Remove(entity);
                        _context.SaveChanges();
                        return Ok("Venda removida.");
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"DeleteVenda");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    }
}