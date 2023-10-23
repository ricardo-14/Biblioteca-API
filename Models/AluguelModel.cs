namespace API_Biblioteca.Models
{
    public class AluguelModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataAluguel { get; set; }
        public ClienteModel Cliente { get; set; }
        public LivroModel Livro { get; set; }
    }
}
