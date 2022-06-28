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
    public class ProductoController : ControllerBase
    {
        [HttpGet("listaproducto")]
        public async Task<IActionResult> GetProductos()
        {
            return Ok(await Task.Run(() => new productoDAO().Listado()));
        }
        [HttpPost("agregarproducto")]
        public async Task<ActionResult> PostSeller(Producto producto)
        {
            return Ok(await Task.Run(() => new productoDAO().Agregar(producto)));
        }
        [HttpPut("actualizarproducto")]
        public async Task<ActionResult> PutSeller(Producto producto)
        {
            return Ok(await Task.Run(() => new productoDAO().Actualizar(producto)));
        }
        [HttpGet("listaproductoxid")]
        public async Task<IActionResult> GetProductosxid(string id)
        {
            return Ok(await Task.Run(() => new productoDAO().Listadoprodxid(id)));
        }
        [HttpGet("listaproductoxidnegocio")]
        public async Task<IActionResult> GetProductosxidnegocio(string id)
        {
            return Ok(await Task.Run(() => new productoDAO().Listadoprodxidnegocio(id)));
        }
    }
}
