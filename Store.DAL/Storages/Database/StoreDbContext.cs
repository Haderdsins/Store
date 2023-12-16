using Microsoft.EntityFrameworkCore;
using Store.DAL.Models;

namespace Store.DAL.Database;

public sealed class StoreDbContext : DbContext
{
    public DbSet<Shop> Stores { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<OmgItem> Items { get; set; }

    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    { 
    }
}