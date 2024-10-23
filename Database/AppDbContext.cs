using Microsoft.EntityFrameworkCore;
using Inventory_Manager.Models.Categories;
using Inventory_Manager.Models.Products;

namespace Inventory_Manager.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=mydb;User ID=workshop;Password=changeme;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasIndex(x => x.CreatedAt);
        modelBuilder.Entity<Product>().HasIndex(x => x.CreatedAt);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
