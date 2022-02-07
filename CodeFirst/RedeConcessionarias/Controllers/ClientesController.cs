using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using RedeConcessionarias.Models;
using RedeConcessionarias.Log;

namespace RedeConcessionarias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase{
        
        [HttpGet]
        public IActionResult GetTodosClientes() { //Lista todos os Clientes da empresa
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
            
        [HttpGet("byId/{ClienteId}")] // Busca o cliente pelo Id
        public IActionResult GetClientesById(int ClienteId){
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var cliente = _context.Clientes.FirstOrDefault(c=>c.ClienteId == ClienteId);
                    if(cliente == null){
                        return StatusCode(404,"Cliente não encontrado");
                    }
                    return Ok(cliente);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetClienteById");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpPost]//Cadastra o cliente no banco de dados
        public IActionResult PostCliente([FromBody] Cliente cliente){
            try{
                using (var _context = new RedeConcessionariaContext()){
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                    return Ok(cliente);
                }
            }
            catch (Exception ex){ 
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpPut("{ClienteId}")]
        public IActionResult PutCliente(int ClienteId, [FromBody] Cliente cliente){
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var entity = _context.Clientes.Find(ClienteId);
                    if(entity == null){
                        return BadRequest("Cliente não localizado");
                    }
                        _context.Entry(entity).CurrentValues.SetValues(cliente);
                        _context.SaveChanges();
                        return Ok(cliente);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }

        
        }
    
        [HttpDelete("{ClienteId}")]
        public IActionResult DeleteCliente(int ClienteId)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Clientes.Find(ClienteId);
                    if(entity == null)
                    {
                        return BadRequest("Cliente não localizado.");
                    }
                        _context.Clientes.Remove(entity);
                        _context.SaveChanges();
                        return Ok("Cliente Removido");
                }
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    }    
}    