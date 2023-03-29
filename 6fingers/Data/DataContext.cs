using _6fingers.Models;
using Microsoft.EntityFrameworkCore;

namespace _6fingers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

    }

}