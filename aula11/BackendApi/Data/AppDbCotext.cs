using Microsoft.EntityFrameworkCore;
using BackendApi.Models;

namespace BackendApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext(
            DbContextOptions<AppDbContext> options
        ) : base(options)
        {
        }
    }
}