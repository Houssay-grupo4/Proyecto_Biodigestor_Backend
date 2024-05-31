using Microsoft.EntityFrameworkCore;

namespace Proyecto.Biodigestor.Models
{
    public class TempsContext : DbContext
    {
        public TempsContext(DbContextOptions<TempsContext> options) : base(options)
        {
        }

        public DbSet<Temp> Temps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Temp>().HasIndex( temp => temp.IdTemp).IsUnique();
        }
    }
}