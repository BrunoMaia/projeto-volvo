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
    public class VendedorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTodosVendedores(){
            /* Lista todos os vendedores da empresa */
            try{
                using(var _context = new RedeConcessionariaContext()){
                    return Ok(_context.Vendedores.ToList());
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetTodosVendedores");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    
        [HttpGet("byId/{VendedorId}")] // Busca o vendedor pela matrícula
        public IActionResult GetVendedorByMatricula(int VendedorId){
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var vendedor = _context.Vendedores.FirstOrDefault(v=>v.VendedorId == VendedorId);
                    if(vendedor == null){
                        return NotFound("Vendedor não encontrado.");
                    }
                    return Ok(vendedor);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetVendedorByMatricula");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpGet("vendasId")]
        public IActionResult GetVendasVendedor (int VendedorId) { //Lista as vendas que o vendedor participou
                try{
                    using(var _context = new RedeConcessionariaContext()){
                        var vendedor = _context.Vendedores.Include(x => x.Vendas).FirstOrDefault(c=>c.VendedorId == VendedorId);
                        if(vendedor == null){
                            return StatusCode(404,"Vendedor não encontrado");
                        }                
                        return Ok(vendedor);
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,1,"GetVendasVendedor");
                    return StatusCode(500,"Erro no Servidor");
                }
        }

        [HttpGet("byCpfVendedor/{CpfVendedor}")]
        public IActionResult GetVendedorByCPF(string CpfVendedor){
            /* Obtem vendedor por cpf */
            try{
            using(var _context = new RedeConcessionariaContext()){
                    var vendedor = _context.Vendedores.FirstOrDefault(v=>v.CpfVendedor == CpfVendedor);
                    if(vendedor == null){
                        return NotFound("Vendedor não encontrado");
                    }
                    return Ok(vendedor);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"GetVendedorByCPF");
                return StatusCode(500,"Erro no Servidor");
            }
        }
    
        [HttpPost]
        public IActionResult PostVendedor([FromBody] Vendedor vendedor){
            /* Cadastra o vendedor no banco de dados */
            try{
                using (var _context = new RedeConcessionariaContext()){
                    _context.Vendedores.Add(vendedor);
                    _context.SaveChanges();
                    return Ok(vendedor);
                }
                
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"PostVendedor");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpPut("{VendedorId}")]
        public IActionResult PutVendedor(int VendedorId, [FromBody] Vendedor vendedor){
            /* altera o vendedor */
            try {
                using(var _context = new RedeConcessionariaContext()){
                    var entity = _context.Vendedores.Find(VendedorId);
                    if(entity == null){
                        return BadRequest("Vendedor não encontrado.");
                    }
                        _context.Entry(entity).CurrentValues.SetValues(vendedor);
                        _context.SaveChanges();
                        return Ok(vendedor);
                }
            }
            catch (Exception ex){
                Logger.AdicionaLog(ex.Message,1,"PutVendedor");
                return StatusCode(500,"Erro no Servidor");
            }
        }

        [HttpDelete("{VendedorId}")]
        public IActionResult DeleteVendedor(int VendedorId){
            /* apaga o vendedor */
           try{
                using(var _context = new RedeConcessionariaContext()){
                    var entity = _context.Vendedores.Find(VendedorId);
                    if(entity == null){
                        return BadRequest("Vendedor não encontrado.");
                    }
                        _context.Vendedores.Remove(entity);
                        _context.SaveChanges();
                        return Ok("Vendedor removido.");
                }
            }
            catch (Exception ex){
               Logger.AdicionaLog(ex.Message,1,"DeleteVendedor");
                    return StatusCode(500,"Erro no Servidor");
            }
        }
    }
}