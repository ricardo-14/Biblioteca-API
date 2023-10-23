using API_Biblioteca.Data;
using API_Biblioteca.Models;
using API_Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca.Services
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _dbContext;

        public ClienteService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ClienteModel>> GetClientesAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<ClienteModel> GetClienteByIdAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }
        public async Task<IEnumerable<AluguelModel>> GetAlugeisDoCliente(int idCliente)
        {
            return await _dbContext.Alugueis
                .Where(a => a.ClienteId == idCliente)
                .Include(a => a.Cliente)
                .Include(a => a.Livro)
                .ToListAsync();
        }
        public async Task<IEnumerable<LivroModel>> GetLivrosAlugadosDoCliente(int idCliente)
        {
            return await _dbContext.Alugueis
                 .Where(a => a.ClienteId == idCliente)
                 .Select(a => a.Livro)
                 .Distinct()
                 .ToListAsync();
        }
        public async Task CreateClienteAsync(ClienteModel cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(int id, ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            _dbContext.Entry(cliente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return;
            }

            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }
    }
}
