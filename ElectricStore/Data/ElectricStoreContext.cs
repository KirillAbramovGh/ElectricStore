using ElectricStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricStore.Data
{
    public class ElectricStoreContext : DbContext
    {
        public ElectricStoreContext(DbContextOptions<ElectricStoreContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Article> Articles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}