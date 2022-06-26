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
    public class NegocioController : ControllerBase
    {
        [HttpGet("listanegocio")]
        public async Task<IActionResult> GetNegocios()
        {
            return Ok(await Task.Run(() => new negocioDAO().Listado()));
        }
        [HttpPost("agregarnegocio")]
        public async Task<ActionResult> PostSeller(Negocio negocio)
        {
            return Ok(await Task.Run(() => new negocioDAO().Agregar(negocio)));
        }
        [HttpPut("actualizarnegocio")]
        public async Task<ActionResult> PutSeller(Negocio negocio)
        {
            return Ok(await Task.Run(() => new negocioDAO().Actualizar(negocio)));
        }
        [HttpGet("listanegocioxid")]
        public async Task<IActionResult> GetNegociosxid(string id)
        {
            return Ok(await Task.Run(() => new negocioDAO().ListadoNegocioxid(id)));
        }
    }
}
