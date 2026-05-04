using Microsoft.EntityFrameworkCore;
using SupplyTrack.Models;

namespace SupplyTrack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Mercadoria> Mercadorias { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mercadoria>().HasKey(m => m.Id);
        }
    }


}