using DSV.Models;
using Microsoft.EntityFrameworkCore;

namespace DSV.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

    }
}

