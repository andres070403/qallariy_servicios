using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using qallariy_servicios.Models;
using qallariy_servicios.DAO;
using System.Threading.Tasks;

namespace qallariy_servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("listaventa")]
        public async Task<IActionResult> GetVentas()
        {
            return Ok(await Task.Run(() => new ventasDAO().Listado()));
        }
        [HttpPost("agregarventa")]
        public async Task<ActionResult> PostSeller(Venta venta)
        {
            return Ok(await Task.Run(() => new ventasDAO().Agregar(venta)));
        }
    }
}
