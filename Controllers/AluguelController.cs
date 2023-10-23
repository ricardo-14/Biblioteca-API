using API_Biblioteca.DTOs;
using API_Biblioteca.Models;
using API_Biblioteca.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _aluguelService;

        public AluguelController(IAluguelService aluguelService)
        {
            _aluguelService = aluguelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AluguelModel>>> GetAlugueis()
        {
            var alugueis = await _aluguelService.GetAlugueisAsync();
            return Ok(alugueis);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AluguelModel>> GetAluguel(int id)
        {
            var alugueis = await _aluguelService.GetAluguelByIdAsync(id);
            return Ok(alugueis);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAluguel(AluguelDto aluguel)
        {
            var aluguelModel = new AluguelModel
            {
                Id = aluguel.Id,
                DataAluguel = aluguel.DataAluguel,
                ClienteId = aluguel.ClienteId,
                LivroId = aluguel.LivroId
            };

            await _aluguelService.CreateAluguelAsync(aluguelModel);
            return CreatedAtAction(nameof(GetAluguel), new { id = aluguel.Id }, aluguel);
        }
    }
}
