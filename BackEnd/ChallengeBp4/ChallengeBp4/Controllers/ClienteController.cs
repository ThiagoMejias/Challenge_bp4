using ChallengeBp4.Conexion;
using ChallengeBp4.Modelos;
using ChallengeBp4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ChallengeBp4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("GetAll")]


        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return await _clienteService.GetAll();
        }

        [HttpGet("Get/{id}")]
        
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _clienteService.Get(id);
            if(cliente == null)
                return NotFound("Cliente no encontrado");
            return Ok(cliente); 
        }

        [HttpGet("Search/{nombre}")]
        public async Task<ActionResult<Cliente>> Search(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return BadRequest("El nombre es invalido");

            var clientes = await _clienteService.Search(nombre);

            if (clientes.Count == 0)
            {
                return NotFound("No se encontraron clientes con ese nombre");
            }

            return Ok(clientes);        
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Cliente>> Insert(Cliente cliente)
        {
                
            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(errores);
            }
            else
            {
                string mensajeDeError = ValidadorCliente.validarCliente(cliente);
                if(mensajeDeError == "")
                {
                    var clienteNuevo = await _clienteService.Insert(cliente);
                    if (clienteNuevo is null)
                    {
                        return BadRequest("Algo fallo agregando el cliente");
                    }
                    return Ok(clienteNuevo);
                }
                else
                {
                    return BadRequest(mensajeDeError);
                }
                
            }
        }

        [HttpPut("Update/{id}")]

        public async Task<ActionResult<Cliente>> Insert(int id, Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(errores);
            }
            else
            {
                string mensajeDeError = ValidadorCliente.validarCliente(cliente);
                if (mensajeDeError == "")
                {
                    var clienteNuevo = await _clienteService.Update(id,cliente);
                    if (clienteNuevo is null)
                    {
                        return BadRequest("Algo fallo modificando al cliente");
                    }
                    return Ok(clienteNuevo);
                }
                else
                {
                    return BadRequest(mensajeDeError);
                }

            }
        }


    }
}
