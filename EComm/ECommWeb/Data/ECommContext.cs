using Microsoft.EntityFrameworkCore;

namespace ECommWeb.Data;

public class ECommContext : DbContext
{
    public ECommContext(DbContextOptions<ECommContext> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
}
