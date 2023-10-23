using API_Biblioteca.Data;
using API_Biblioteca.Models;
using API_Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca.Services
{
    public class LivroService : ILivroService
    {
        private readonly DataContext _dbContext;

        public LivroService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LivroModel>> GetLivrosAsync()
        {
            return await _dbContext.Livros.ToListAsync();
        }
        public async Task<LivroModel> GetLivroByIdAsync(int id)
        {
            return await _dbContext.Livros.FindAsync(id);
        }

        public async Task CreateLivroAsync(LivroModel livro)
        {
            _dbContext.Livros.Add(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLivroAsync(int id)
        {
            var livro = await _dbContext.Livros.FindAsync(id);
            if (livro == null) return;

            _dbContext.Livros.Remove(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLivroAsync(int id, LivroModel livro)
        {
            if (id != livro.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            _dbContext.Entry(livro).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
