using Microsoft.EntityFrameworkCore;

namespace Proyecto.Biodigestor.Models
{
    public class ClientesContext : DbContext
    {
        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasIndex(cliente => cliente.IdCliente).IsUnique();
        }
    }
}
