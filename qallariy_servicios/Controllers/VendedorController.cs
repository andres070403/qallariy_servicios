using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using qallariy_servicios.DAO;

namespace qallariy_servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {

        [HttpPost("agregarvendedor")]
        public async Task<ActionResult> PostSeller(Vendedor vendedor)
        {
            return Ok(await Task.Run(() => new vendedorDAO().Agregar(vendedor)));
        }
        [HttpPut("actualizarvendedor")]
        public async Task<ActionResult> PutSeller(Vendedor vendedor)
        {
            return Ok(await Task.Run(() => new vendedorDAO().Actualizar(vendedor)));
        }
        [HttpGet("buscar")]
        public async Task<IActionResult> GetBuscar(string correo)
        {
            return Ok(await Task.Run(() => new vendedorDAO().Buscar(correo)));
        }

    }
}
