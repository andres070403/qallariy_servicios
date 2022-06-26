using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.DAO;
using qallariy_servicios.Models;
using qallariy_servicios.Controllers;

namespace qallariy_servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        [HttpGet("listametodopago")]
        public async Task<IActionResult> GetMetodoPago()
        {
            return Ok(await Task.Run(() => new metodoPagoDAO().listado()));
        }
        [HttpPost("agregarmetodopago")]
        public async Task<ActionResult> PostMetodoPago(MetodoPago metodoPago)
        {
            return Ok(await Task.Run(() => new metodoPagoDAO().Agregar(metodoPago)));
        }
        [HttpGet("listarmetodopagovendedor")]
        public async Task<ActionResult> PutMeotodPago(int metodoPago)
        {
            return Ok(await Task.Run(() => new metodoPagoDAO().ListarPorVendedor(metodoPago)));
        }
    }
}
