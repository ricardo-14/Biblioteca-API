using API_Biblioteca.Models;

namespace API_Biblioteca.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteModel>> GetClientesAsync();
        Task<ClienteModel> GetClienteByIdAsync(int id);
        Task<IEnumerable<AluguelModel>> GetAlugeisDoCliente(int idCliente);
        Task<IEnumerable<LivroModel>> GetLivrosAlugadosDoCliente(int idCliente);
        Task CreateClienteAsync(ClienteModel cliente);
        Task UpdateClienteAsync(int id, ClienteModel cliente);
        Task DeleteClienteAsync(int id);
    }
}
