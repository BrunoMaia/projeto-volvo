using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using RedeConcessionarias.Models;
using RedeConcessionarias.Log;
using System.Linq;

namespace RedeConcessionarias.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase{
        [HttpGet]
        public IActionResult GetTodosClientes(){ 
            /* Lista todos os clientes da empresa. Retornando erro 500 se não conseguir concluir */
                try{
                    using(var _context = new RedeConcessionariaContext()){
                    return Ok(_context.Clientes.ToList());
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,1,"GetTodosClientes");
                    return StatusCode(500,"Erro no Servidor");
                }
        }

        [HttpGet("vendasId")]
        public IActionResult GetVendasClientes(int ClienteId) {
            /* Lista as vendas que o cliente participou por seu Id */
                try{
                    using(var _context = new RedeConcessionariaContext()){
                        var Cliente = _context.Clientes.Include(x => x.Vendas).FirstOrDefault(c=>c.ClienteId == ClienteId);
                    if(Cliente == null){
                        return StatusCode(404,"Cliente não encontrado");
                    }
                    return Ok(Cliente);
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,1,"GetTodosClientes");
                    return StatusCode(500,"Erro no Servidor");
                }
        }

        [HttpGet("byId/{ClienteId}")] 
        public IActionResult GetClientesById(int ClienteId){
            /* Busca o cliente pelo Id */
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var Cliente = _context.Clientes.FirstOrDefault(c=>c.ClienteId == ClienteId);
                    if(Cliente == null){
                        return StatusCode(404,"Cliente não encontrado");
                    }
                    return Ok(Cliente);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetClienteById");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpPost]
        public IActionResult PostCliente([FromBody] Cliente Cliente){
            /* Cadastra o cliente no banco de dados */
            try{
                using (var _context = new RedeConcessionariaContext()){
                    _context.Clientes.Add(Cliente);
                    _context.SaveChanges();
                    return Ok(Cliente);
                }
            }
            catch (Exception ex){ 
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpPut("{ClienteId}")]
        public IActionResult PutCliente(int ClienteId, [FromBody] Cliente Cliente){
            /* Altera o cliente cadastrado */
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var Entity = _context.Clientes.Find(ClienteId);
                    if(Entity == null){
                        return BadRequest("Cliente não localizado");
                    }
                        _context.Entry(Entity).CurrentValues.SetValues(Cliente);
                        _context.SaveChanges();
                        return Ok(Cliente);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"PutCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    
        [HttpDelete("{ClienteId}")]
        public IActionResult DeleteCliente(int ClienteId){
            /* Apaga o cliente pelo id */
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var Entity = _context.Clientes.Find(ClienteId);
                    if(Entity == null){
                        return BadRequest("Cliente não localizado.");
                    }
                        _context.Clientes.Remove(Entity);
                        _context.SaveChanges();
                        return Ok("Cliente Removido");
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"DeleteCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    }    
}    