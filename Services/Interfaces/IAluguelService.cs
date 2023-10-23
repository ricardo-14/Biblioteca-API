using API_Biblioteca.Models;

namespace API_Biblioteca.Services.Interfaces
{
    public interface IAluguelService
    {
        Task<IEnumerable<AluguelModel>> GetAlugueisAsync();
        Task<AluguelModel> GetAluguelByIdAsync(int id);
        Task CreateAluguelAsync(AluguelModel aluguel);
    }
}
