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
    public class VendedorController : ControllerBase
    {

        [HttpGet]
        public IActionResult getTodosVendedores() //Lista todos os vendedores da empresa
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    return Ok(_context.Vendedores.ToList());
                }
            
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }
    
        [HttpGet("byId/{VendedorId}")] // Busca o vendedor pela matrícula

        public IActionResult getVendedorByMatricula(int VendedorId)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var vendedor = _context.Vendedores.FirstOrDefault(v=>v.VendedorId == VendedorId);
                    if(vendedor == null)
                    {
                        return NotFound("Vendedor não encontrado.");
                    }
                    return Ok(vendedor);
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }

        [HttpGet("byCpfVendedor/{CpfVendedor}")]
        public IActionResult getVendedorByCPF(string CpfVendedor)
        {
            try
            {
            using(var _context = new RedeConcessionariaContext())
                {

                    var vendedor = _context.Vendedores.FirstOrDefault(v=>v.CpfVendedor == CpfVendedor);
                    if(vendedor == null)
                    {
                        return NotFound("Vendedor não encontrado");
                    }
                    return Ok(vendedor);
                }
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    
        [HttpPost]
        public IActionResult PostVendedor([FromBody] Vendedor vendedor) //Cadastra o vendedor no banco de dados
        {
            try
            {
                using (var _context = new RedeConcessionariaContext())
                {
                    _context.Vendedores.Add(vendedor);
                    _context.SaveChanges();
                    return Ok(vendedor);
                }
                
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }

            
        }

        [HttpPut("{VendedorId}")]
        public IActionResult PutVendedor(int VendedorId, [FromBody] Vendedor vendedor)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendedores.Find(VendedorId);
                    if(entity == null)
                    {
                        return BadRequest("Vendedor não encontrado.");
                    }
                        _context.Entry(entity).CurrentValues.SetValues(vendedor);
                        _context.SaveChanges();
                        return Ok(vendedor);
                }
            }
            catch (Exception ex)
            {
                Logger.AdicionaLog(ex.Message,1,"PostCliente");
                return StatusCode(500,"Erro no Servidor");
            }
            
        }

        [HttpDelete("{VendedorId}")]
        public IActionResult DeleteVendedor(int VendedorId)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendedores.Find(VendedorId);
                    if(entity == null)
                    {
                        return BadRequest("Vendedor não encontrado.");
                    }
                        _context.Vendedores.Remove(entity);
                        _context.SaveChanges();
                        return Ok("Vendedor removido.");
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