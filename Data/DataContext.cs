using API_Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<AluguelModel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Livro)
                .WithMany()
                .HasForeignKey(a => a.LivroId);
        }
    }
}
