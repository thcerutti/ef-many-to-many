using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Contexts;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public StoreContext() : base() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=many-to-many;User Id=sa;Password=Sql2019-pw;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithMany(p => p.Categories);

        modelBuilder.Entity<Product>()
            .HasMany(c => c.Categories)
            .WithMany(c => c.Products);
    }
}