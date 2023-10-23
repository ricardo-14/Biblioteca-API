using API_Biblioteca.Models;

namespace API_Biblioteca.Services.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroModel>> GetLivrosAsync();
        Task<LivroModel> GetLivroByIdAsync(int id);
        Task CreateLivroAsync(LivroModel livro);
        Task UpdateLivroAsync(int id, LivroModel livro);
        Task DeleteLivroAsync(int id);
    }
}
