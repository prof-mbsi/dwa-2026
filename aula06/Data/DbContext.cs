using Microsoft.EntityFrameworkCore;
using AulaApi.Models;

namespace AulaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}