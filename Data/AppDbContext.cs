using AutoresCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoresCRUD.Data
{
    public class AppDbContext : DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
            
        }

        public DbSet<AutorModel> Autor { get; set; }
        public DbSet<LivroModel> Livro { get; set; } 
    }
}
