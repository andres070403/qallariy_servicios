using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.DAO;
using qallariy_servicios.Models;

namespace qallariy_servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        [HttpGet("categorias")]
        public async Task<IActionResult> GetCategorias()
        {
            return Ok(await Task.Run(() => new categoriaDAO().listado()));
        }
        [HttpGet("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            return Ok(await Task.Run(() => new departamentoDAO().listado()));
        }
        [HttpGet("provincia")]
        public async Task<IActionResult> GetProvincias(int id)
        {
            return Ok(await Task.Run(() => new provinciaDAO().buscarPorDepartamento(id)));
        }
        [HttpGet("estado")]
        public async Task<IActionResult> GetEstados()
        {
            return Ok(await Task.Run(() => new estadoDAO().listado()));
        }
        [HttpGet("distritos")]
        public async Task<IActionResult> GetDistritos()
        {
            return Ok(await Task.Run(() => new distritoDAO().listado()));
        }
        [HttpGet("distritosxprovincia")]
        public async Task<IActionResult> GetDistritosxprovincia(int id)
        {
            return Ok(await Task.Run(() => new distritoDAO().buscarDistritoxProvincia(id)));
        }
        [HttpGet("tipoDocumento")]
        public async Task<IActionResult> GetTipoDocumento()
        {
            return Ok(await Task.Run(() => new tipoDocumentoDAO().listado()));
        }
        [HttpGet("membresia")]
        public async Task<IActionResult> GetMembresia()
        {
            return Ok(await Task.Run(() => new membresiaDAO().listado()));
        }
        [HttpGet("listavendedor")]
        public async Task<IActionResult> GetListaVendedor()
        {
            return Ok(await Task.Run(() => new vendedorDAO().Listado()));
        }
    }

}
