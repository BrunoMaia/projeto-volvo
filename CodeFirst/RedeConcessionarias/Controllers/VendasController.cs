using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using RedeConcessionarias.Models;
using RedeConcessionarias.Log;




namespace RedeConcessionarias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

        
        [HttpGet]
        public IActionResult getTodasVendas() //Lista todas as vendas da empresa
        {
            try
            {
                
                using(var _context = new RedeConcessionariaContext())
                {
                    return Ok(_context.Vendas.ToList());
                }
            
            }
            catch (Exception ex)
            {
               Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }
    
        [HttpGet("byId/{VendasId}")] // Busca o vendedor pela matrícula

        public IActionResult getVendasById(int VendasId)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var venda = _context.Vendas.FirstOrDefault(v=>v.VendasId == VendasId);
                    if(venda == null)
                    {
                        return NotFound("Venda não localizada.");
                    }
                    return Ok(venda);
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        
        }


        [HttpPost]
        public IActionResult PostVenda([FromBody] Venda venda) //Cadastra a venda no banco de dados
        {
            try
            {
                using (var _context = new RedeConcessionariaContext())
                {
                    _context.Vendas.Update(venda);
                    _context.SaveChanges();
                    return Ok(venda);
                    
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }

        [HttpPut("{VendasId}")]
        public IActionResult PutVenda(int VendasId, [FromBody] Venda venda)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendas.Find(VendasId);
                    if(entity == null)
                    {
                        return BadRequest("Venda não localizada.");
                    }
                        _context.Entry(entity).CurrentValues.SetValues(venda);
                        _context.SaveChanges();
                        return Ok(venda);
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        
        }

        [HttpDelete("{VendasId}")]
        public IActionResult DeleteVenda(int VendasId)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendas.Find(VendasId);
                    if(entity == null)
                    {
                        return BadRequest("Venda não localizada.");
                    }
                        _context.Vendas.Remove(entity);
                        _context.SaveChanges();
                        return Ok("Venda removida.");
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