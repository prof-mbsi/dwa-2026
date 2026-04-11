using Microsoft.EntityFrameworkCore;
using AulaApi.Models;

namespace AulaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}