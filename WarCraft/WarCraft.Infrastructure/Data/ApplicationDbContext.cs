using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      //  public DbSet<Category> Categories { get; set; }
      //  public DbSet<Manufacturer> Manufacturers { get; set; }
      //  public DbSet<Order> Orders { get; set; }
      //  public DbSet<Product> Products { get; set; }
    }
}
