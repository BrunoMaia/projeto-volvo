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
    public class VeiculoController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult getTodosVeiculos() //Lista todos os veículos da empresa
        {
            try
            {
                
                using(var _context = new RedeConcessionariaContext())
                {
                    return Ok(_context.Veiculos.ToList());
                }
            
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }
    
        
        [HttpGet("byId/{VeiculoId}")] // Busca o veiculo pelo Id
        public IActionResult getVeiculosById(int VeiculoId)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var veiculo = _context.Veiculos.FirstOrDefault(c=>c.VeiculoId == VeiculoId);
                    if(veiculo == null)
                    {
                        return NotFound("Veículo não encontrado");
                    }
                    return Ok(veiculo);
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpGet("byChassiVeiculo/{ChassiVeiculo}")] // Busca o veiculo pelo Chassi
        public IActionResult getVeiculoByChassi(string ChassiVeiculo)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var veiculo = _context.Veiculos.FirstOrDefault(v=>v.ChassiVeiculo == ChassiVeiculo);
                    if(veiculo == null)
                    {
                        return NotFound("Veículo não encontrado");
                    }
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }
        [HttpPost]
        public IActionResult PostVeiculo([FromBody] Veiculo veiculo) //Cadastra o veiculo no banco de dados
        {
            try
            {
                using (var _context = new RedeConcessionariaContext())
                {
                    _context.Veiculos.Add(veiculo);
                    _context.SaveChanges();
                    return Ok(veiculo);
                    
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }


        [HttpPut("{VeiculoId}")]
        public IActionResult PutVeiculo(int VeiculoId, [FromBody] Veiculo veiculo)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Veiculos.Find(VeiculoId);
                    if(entity == null)
                    {
                        return BadRequest("Veículo não encontrado.");
                    }
                        _context.Entry(entity).CurrentValues.SetValues(veiculo);
                        _context.SaveChanges();
                        return Ok(veiculo);
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }

        [HttpDelete("{VeiculoId}")]
        public IActionResult DeleteVeiculo(int VeiculoId)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Veiculos.Find(VeiculoId);
                if(entity == null)
                {
                    return BadRequest("Veículo não encontrado.");
                }
                    _context.Veiculos.Remove(entity);
                    _context.SaveChanges();
                    return Ok("Veículo Removido");
            }
        }
    }
}