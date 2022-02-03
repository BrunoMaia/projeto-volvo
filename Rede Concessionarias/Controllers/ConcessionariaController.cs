using Microsoft.AspNetCore.Mvc;
using MVCWebApi.Models;

namespace Proprietario.Controllers;
{
    [Route("api/proprietario/[controller]")]
    [ApiController]
    public class Proprietario.Controller : Controller
    {
        [HttpPost]
        [HttpGet]
        [HttpPut("{id}")]
        [HttpDelete("{id}")]
    }
}

namespace Veiculo.Controllers;
{
    [Route("api/veiculo/[controller]")]
    [ApiController]
    public class Veiculo.Controller : Controller
    {
        [HttpPost]
        [HttpGet]
        [HttpPut("{id}")]
        [HttpDelete("{id}")]
    }
}

namespace Vendedor.Controllers;
{
    [Route("api/vendedor/[controller]")]
    [ApiController]
    public class Vendedor.Controller : Controller
    {
        [HttpPost]
        [HttpGet]
        [HttpPut("{id}")]
        [HttpDelete("{id}")]
    }
}

namespace Venda.Controllers;
{
    [Route("api/venda/[controller]")]
    [ApiController]
    public class Venda.Controller : Controller
    {
        [HttpPost]
        [HttpGet]
        [HttpPut("{id}")]
        [HttpDelete("{id}")]
    }
}
