using API_Biblioteca.Data;
using API_Biblioteca.Models;
using API_Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca.Services
{
    public class AluguelService : IAluguelService
    {
        private readonly DataContext _dbContext;

        public AluguelService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<AluguelModel>> GetAlugueisAsync()
        {
            return await _dbContext.Alugueis.Include(a => a.Cliente).Include(a => a.Livro).ToListAsync();
        }

        public async Task<AluguelModel?> GetAluguelByIdAsync(int id)
        {
            return await _dbContext.Alugueis.Include(a => a.Cliente).Include(a => a.Livro)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task CreateAluguelAsync(AluguelModel aluguel)
        {
            _dbContext.Alugueis.Add(aluguel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
