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
            
        [HttpGet("byId/{IdCliente}")] // Busca o cliente pelo Id
        public IActionResult GetClientesById(int IdCliente){
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var cliente = _context.Clientes.FirstOrDefault(c=>c.IdCliente == IdCliente);
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

        [HttpPut("{IdCliente}")]
        public IActionResult PutCliente(int IdCliente, [FromBody] Cliente cliente){
            try{
                using(var _context = new RedeConcessionariaContext()){
                    var entity = _context.Clientes.Find(IdCliente);
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
    
        [HttpDelete("{IdCliente}")]
        public IActionResult DeleteCliente(int IdCliente)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Clientes.Find(IdCliente);
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
    
        
        [HttpGet("byIdVeiculo/{IdVeiculo}")] // Busca o veiculo pelo Id
        public IActionResult getVeiculosById(int IdVeiculo)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var veiculo = _context.Veiculos.FirstOrDefault(c=>c.IdVeiculo == IdVeiculo);
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


        [HttpPut("{IdVeiculo}")]
        public IActionResult PutVeiculo(int IdVeiculo, [FromBody] Veiculo veiculo)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Veiculos.Find(IdVeiculo);
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



        [HttpDelete("{IdVeiculo}")]
        public IActionResult DeleteVeiculo(int IdVeiculo)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Veiculos.Find(IdVeiculo);
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
    
        [HttpGet("byMatriculaVendedor/{MatriculaVendedor}")] // Busca o vendedor pela matrícula

        public IActionResult getVendedorByMatricula(int MatriculaVendedor)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var vendedor = _context.Vendedores.FirstOrDefault(v=>v.MatriculaVendedor == MatriculaVendedor);
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

        [HttpPut("{IdVendedor}")]
        public IActionResult PutVendedor(int IdVendedor, [FromBody] Vendedor vendedor)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendedores.Find(IdVendedor);
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

        [HttpDelete("{IdVendedor}")]
        public IActionResult DeleteVendedor(int IdVendedor)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendedores.Find(IdVendedor);
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
    
        [HttpGet("byIdVendas/{IdVendas}")] // Busca o vendedor pela matrícula

        public IActionResult getVendaByIdVendas(int IdVendas)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {

                    var venda = _context.Vendas.FirstOrDefault(v=>v.IdVendas == IdVendas);
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

        [HttpPut("{IdVendas}")]
        public IActionResult PutVenda(int IdVendas, [FromBody] Venda venda)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendas.Find(IdVendas);
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

        [HttpDelete("{IdVendas}")]
        public IActionResult DeleteVenda(int IdVendas)
        {
            try
            {
                using(var _context = new RedeConcessionariaContext())
                {
                    var entity = _context.Vendas.Find(IdVendas);
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