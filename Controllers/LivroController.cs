using API_Biblioteca.Models;
using API_Biblioteca.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroModel>>> GetLivros()
        {
            var livros = await _livroService.GetLivrosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroModel>> GetLivroById(int id)
        {
            var livro = await _livroService.GetLivroByIdAsync(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLivro(LivroModel livro)
        {
            await _livroService.CreateLivroAsync(livro);
            return CreatedAtAction(nameof(GetLivroById), new { id = livro.Id }, livro);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLivro(int id, LivroModel livro)
        {
            if (id != livro.Id) return BadRequest();
            await _livroService.UpdateLivroAsync(id, livro);
            return Ok("Livro atualizado com sucesso!");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLivro(int id)
        {
            await _livroService.DeleteLivroAsync(id);
            return Ok("Livro excluído com sucesso!");
        }
    }
}
