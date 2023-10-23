using API_Biblioteca.Models;
using API_Biblioteca.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpGet("{id}/alugueis")]
        public async Task<ActionResult<ClienteModel>> GetAlugeisDoCliente(int id)
        {
            var alugueis = await _clienteService.GetAlugeisDoCliente(id);
            return Ok(alugueis);
        }

        [HttpGet("{id}/livros")]
        public async Task<ActionResult<ClienteModel>> GetLivrosAlugadosDoCliente(int id)
        {
            var alugueis = await _clienteService.GetLivrosAlugadosDoCliente(id);
            return Ok(alugueis);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClienteModel cliente)
        {
            await _clienteService.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _clienteService.UpdateClienteAsync(id, cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
