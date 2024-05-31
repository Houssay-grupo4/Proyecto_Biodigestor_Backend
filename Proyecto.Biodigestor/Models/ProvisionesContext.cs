using Microsoft.EntityFrameworkCore;

namespace Proyecto.Biodigestor.Models
{
    public class ProvisionesContext : DbContext
    {
        public ProvisionesContext(DbContextOptions<ProvisionesContext> options) : base(options)
        {
        }

        public DbSet<Provision> Provisiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Provision>().HasIndex(provision => provision.IdProvision).IsUnique();
        }
    }
}
