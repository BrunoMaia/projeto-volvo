using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedeConcessionarias.Models;



namespace RedeConcessionarias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        
        [HttpGet]
        public List<Cliente> getTodosClientes() //Lista todos os Clientes da empresa
        {
             using(var _context = new RedeConcessionariaContext())
            {
                return _context.Clientes.ToList();
            }
        }
      
        
        [HttpGet("byId/{IdCliente}")] // Busca o cliente pelo Id
        public IActionResult getClientesById(int IdCliente)
        {
            using(var _context = new RedeConcessionariaContext())
            {

                var cliente = _context.Clientes.FirstOrDefault(c=>c.IdCliente == IdCliente);
                if(cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }
                return Ok(cliente);
            }
        }

        [HttpPost]
         public Cliente PostCliente([FromBody] Cliente cliente) //Cadastra o cliente no banco de dados
         {
             using (var _context = new RedeConcessionariaContext())
             {
                 _context.Clientes.Add(cliente);
                 _context.SaveChanges();
                 return cliente;
                 
             }
         }

        [HttpPut("{IdCliente}")]
        public void PutCliente(int IdCliente, [FromBody] Cliente cliente)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Clientes.Find(IdCliente);
                if(entity == null)
                {
                    return ;
                }
                    _context.Entry(entity).CurrentValues.SetValues(cliente);
                    _context.SaveChanges();
                    System.Console.WriteLine("Valores do cliente atualizados.");
            }
        }
    
        [HttpDelete("{IdCliente}")]
        public void DeleteCliente(int IdCliente)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Clientes.Find(IdCliente);
                if(entity == null)
                {
                    return ;
                }
                    _context.Clientes.Remove(entity);
                    _context.SaveChanges();
                    System.Console.WriteLine("Cliente Removido.");
            }
        }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        
        [HttpGet]
        public List<Veiculo> getTodosVeiculos() //Lista todos os veículos da empresa
        {
             using(var _context = new RedeConcessionariaContext())
            {
                return _context.Veiculos.ToList();
            }
        }
    

    
        /* 
        [HttpGet("byIdVeiculo/{IdVeiculo}")] // Busca o veiculo pelo Id
        public IActionResult getVeiculosById(int IdVeiculo)
        {
            
            foreach( Veiculo v in veiculos )
            {
                if( v.IdVeiculo == IdVeiculo )
                    return Ok(v);
            }
            
            return NotFound("Veículo não encontrado");
        }

*/

/*
        public IActionResult getVeiculoByChassi(string ChassiVeiculo)
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
    }
}
*/
        

        [HttpPost]
         public Veiculo PostVeiculo([FromBody] Veiculo veiculo) //Cadastra o veiculo no banco de dados
         {
             using (var _context = new RedeConcessionariaContext())
             {
                 _context.Veiculos.Add(veiculo);
                 _context.SaveChanges();
                 return veiculo;
                 
             }
        }
    



        [HttpPut("{IdVeiculo}")]
        public void PutVeiculo(int IdVeiculo, [FromBody] Veiculo veiculo)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Veiculos.Find(IdVeiculo);
                if(entity == null)
                {
                    return ;
                }
                    _context.Entry(entity).CurrentValues.SetValues(veiculo);
                    _context.SaveChanges();
                    System.Console.WriteLine("Valores do veículo atualizados.");
            }
        }



        [HttpDelete("{IdVeiculo}")]
        public void DeleteVeiculo(int IdVeiculo)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Veiculos.Find(IdVeiculo);
                if(entity == null)
                {
                    return ;
                }
                    _context.Veiculos.Remove(entity);
                    _context.SaveChanges();
                    System.Console.WriteLine("Veículo Removido.");
            }
        }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {

        [HttpGet]
        public List<Vendedor> getTodosVendedores() //Lista todos os vendedores da empresa
        {
             using(var _context = new RedeConcessionariaContext())
            {
                return _context.Vendedores.ToList();
            }
        }
      
    

/*
        [HttpGet("byMatriculaVendedor/{MatriculaVendedor}")] // Busca o vendedor pela matrícula

        public IActionResult getVendedorByMatricula(int MatriculaVendedor)
        {
            foreach( Vendedor v in vendedores )
            {
                if( v.MatriculaVendedor == MatriculaVendedor )
                    return Ok(v);
            }
            
            return NotFound("Vendedor não encontrado");
        }


        public IActionResult getVendedorByCPF(string CpfVendedor)
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
    
*/


        [HttpPost]
         public Vendedor PostVendedor([FromBody] Vendedor vendedor) //Cadastra o vendedor no banco de dados
         {
             using (var _context = new RedeConcessionariaContext())
             {
                 _context.Vendedores.Add(vendedor);
                 _context.SaveChanges();
                 return vendedor;
                 
             }
         }

        [HttpPut("{IdVendedor}")]
        public void PutVendedor(int IdVendedor, [FromBody] Vendedor vendedor)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Vendedores.Find(IdVendedor);
                if(entity == null)
                {
                    return ;
                }
                    _context.Entry(entity).CurrentValues.SetValues(vendedor);
                    _context.SaveChanges();
                    System.Console.WriteLine("Valores do vendedor atualizados.");
            }
        }

        [HttpDelete("{IdVendedor}")]
        public void DeleteVendedor(int IdVendedor)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Vendedores.Find(IdVendedor);
                if(entity == null)
                {
                    return ;
                }
                    _context.Vendedores.Remove(entity);
                    _context.SaveChanges();
                    System.Console.WriteLine("Vendedor Removido.");
            }
        }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

        
        [HttpGet]
        public List<Venda> getTodasVendas() //Lista todas as vendas da empresa
        {
             using(var _context = new RedeConcessionariaContext())
            {
                return _context.Vendas.ToList();
            }
        }
    
        /*
        [HttpGet("byIdVendas/{IdVendas}")] // Busca o vendedor pela matrícula

        public IActionResult getVendaByIdVendas(int IdVendas)
        {
            foreach( Venda v in vendas )
            {
                if( v.IdVendas == IdVendas )
                    return Ok(v);
            }
            
            return NotFound("Venda não encontrada");
        }
    */


        [HttpPost]
         public Venda PostVenda([FromBody] Venda venda) //Cadastra a venda no banco de dados
         {
             using (var _context = new RedeConcessionariaContext())
             {
                 _context.Vendas.Add(venda);
                 _context.SaveChanges();
                 return venda;
                 
             }
         }

        [HttpPut("{IdVendas}")]
        public void PutVenda(int IdVendas, [FromBody] Venda venda)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Vendas.Find(IdVendas);
                if(entity == null)
                {
                    return ;
                }
                    _context.Entry(entity).CurrentValues.SetValues(venda);
                    _context.SaveChanges();
                    System.Console.WriteLine("Valores da venda atualizadas.");
            }
        }

        [HttpDelete("{IdVendas}")]
        public void DeleteVenda(int IdVendas)
        {
            using(var _context = new RedeConcessionariaContext())
            {
                var entity = _context.Vendas.Find(IdVendas);
                if(entity == null)
                {
                    return ;
                }
                    _context.Vendas.Remove(entity);
                    _context.SaveChanges();
                    System.Console.WriteLine("Venda Removida.");
            }
        }
    }
}    