using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using RedeConcessionarias.Models;
using RedeConcessionarias.Log;
using System.Linq;

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
                Logger.AdicionaLog(ex.Message,1,"GetTodosVeiculos");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }

        [HttpGet("vendasId")]
        public IActionResult GetVendasVeiculos (int VeiculoId) { //Lista a venda que o veiculo participou por seu Id
                try{
                    using(var _context = new RedeConcessionariaContext()){

                        var veiculo = _context.Veiculos.Include(x => x.Vendas).FirstOrDefault(c=>c.VeiculoId == VeiculoId);
                    if(veiculo == null){
                        return StatusCode(404,"Veículo não encontrado");
                    }
                    
                    return Ok(veiculo);
                    //
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,1,"GetVendasVeiculos");
                    return StatusCode(500,"Erro no Servidor");
                }
        }
    
        
        [HttpGet("byId/{VeiculoId}")] // Busca o veiculo pelo Id
        public IActionResult GetVeiculosById(int VeiculoId)
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
                Logger.AdicionaLog(ex.Message,1,"GetVeiculosById");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpGet("ListVeiculosKM/")] // Lista os veículos pela sua quilometragem
        public IActionResult GetListVeiculoByKm()
        {

            try
            {
                
                using(var _context = new RedeConcessionariaContext())
                {
                    return Ok(_context.Veiculos.OrderBy (v => v.KmVeiculo).ToList());
                }
            
            }

            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"GetListVeiculoByKm");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        
        [HttpGet("ListVeiculosVS/")] // Lista os veículos pela versão do sistema
        public IActionResult GetListVeiculoByVS()
        {

            try
            {
                
                using(var _context = new RedeConcessionariaContext())
                {
                    return Ok(_context.Veiculos.OrderBy (v => v.VersaoSistVeiculo).ToList());
                }
            
            }

            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"GetListVeiculoByVS");
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
                Logger.AdicionaLog(ex.Message,1,"PostVeiculo");
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
                Logger.AdicionaLog(ex.Message,1,"PutVeiculo");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }

        [HttpDelete("{VeiculoId}")]
        public IActionResult DeleteVeiculo(int VeiculoId)
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
                        _context.Veiculos.Remove(entity);
                        _context.SaveChanges();
                        return Ok("Veículo Removido");
                }
            }
            catch (Exception ex)
            {
                
                Logger.AdicionaLog(ex.Message,1,"DeleteVeiculo");
                return StatusCode(500,"Erro no Servidor");
            }
            
            
        }
    }
}