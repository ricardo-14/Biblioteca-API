namespace API_Biblioteca.DTOs
{
    public class AluguelDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataAluguel { get; set; }
    }
}
